using Unity.VisualScripting;
using UnityEngine;

[TypeIcon(typeof(Rigidbody))]
public class MoveWithRigidBody:MoveUnit
{
    private Rigidbody _rigidBody;
    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
        _rigidBody = instance.GetFlow().stack.gameObject.GetComponent<Rigidbody>();
    }

    protected override Vector3 MoveToPosition(Flow flow)
    {
        var targetPosition = flow.GetValue<Vector3>(TargetPosition);
        var speed = flow.GetValue<float>(Speed);
        var toPosition = flow.GetValue<Transform>(ThisTransform).position;
        var distance = Vector3.Distance(toPosition, targetPosition);
        CheckArrive(ref flow,ref distance);
        
        if (!_isArrive)
            _rigidBody.MovePosition(toPosition + (targetPosition - toPosition) * speed * Time.deltaTime);
        
        return toPosition;
    }
}