using Character;
using UnityEngine;
using UnityEngine.Events;

public class CharacterMoveWithNavMeshAndRoute : CharacterMoveWithNavMesh, IRoute
{
    public WayPoint WayPoints;
    public UnityEvent OnNextWayPoint;
    
    public override void Move(Vector3 position)
    {
        NavAgent.SetDestination(position);

        if (ReachedDestination())
            NextWayPoint();
    }
    
    public void RouteMover()
    {
        Move(WayPoints.CurrentWayPoint.Position);
    }
    
    public Vector3 NextWayPoint()
    {
        OnNextWayPoint?.Invoke();
        return WayPoints.NextWayPoint();
    }

    public void OnDrawGizmos()
    {
        WayPoints.GizmosDraw(transform);
    }
}