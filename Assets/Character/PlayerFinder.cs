using Character;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayerFinder: MonoBehaviour, IInitializable, IUpdater, IFinder<IDamageable>
{
    public string TargetTag = "Player";
    public float Radius = 10f;
    public float Angle = 45f;
    
    public float AfterFindAngle = 90f;
    public float AfterFindRadius = 5f;
    
    private float _currentAngle;
    private float _currentRadius;
    
    [ReadOnly]
    public IDamageable Target;
    
    public UnityEvent OnFindTarget;
    public UnityEvent OnLostTarget;
    
    public void Initialize()
    {
        _currentAngle = Angle;
        _currentRadius = Radius;
    }
    
    public IDamageable FindTarget()
    {
        var colliders = Physics.OverlapSphere(transform.position, _currentRadius);
        
        foreach (var collider in colliders)
        {
            if (!collider.CompareTag(TargetTag))
                continue;

            var direction = (collider.transform.position - transform.position).normalized;
            var angle = Vector3.Angle(transform.forward, direction);

            if (!(angle <= _currentAngle))
                continue;

            if(Target == null)
                OnFindTarget?.Invoke();
            
            return Target = collider.GetComponent<IDamageable>();
        }
        
        if(Target != null)
            OnLostTarget?.Invoke();
        
        Target = null;
        return Target;
    }
    
    public Vector3 GetTargetPosition()
    {
        return Target.transform.position;
    }
    public void AfterFind()
    {
        _currentAngle = AfterFindAngle;
        _currentRadius = AfterFindRadius;
    }
    public void Reset()
    {
        _currentAngle = Angle;
        _currentRadius = Radius;
    }
    
    public void OnUpdate()
    {
        if(FindTarget() != null) 
            AfterFind();
        else Reset();
    }
    
    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, Vector3.up, Radius, 10f);
        Handles.color = Color.red;

        if (Application.isPlaying)
        {
            Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, _currentAngle, _currentRadius, 7.5f);
            Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, -_currentAngle, _currentRadius, 7.5f);
        }
        else
        {
            Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, Angle, Radius, 7.5f);
            Handles.DrawWireArc(transform.position, Vector3.up, transform.forward, -Angle, Radius, 7.5f);
        }
        
    }
}