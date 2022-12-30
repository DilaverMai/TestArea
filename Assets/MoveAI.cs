using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

[UnitTitle("Move With NavMeshAgent")]
[TypeIcon(typeof(NavMeshAgent))]
public class MoveAI : MoveUnit
{
    private NavMeshAgent agent;
    
    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
        agent = instance.component.GetComponent<NavMeshAgent>();
        
        if(!agent)
            Debug.LogError("No NavMeshAgent found on " + instance.component.name);
    }

    protected override Vector3 MoveToPosition(Flow flow)
    {
        agent.SetDestination(flow.GetValue<Vector3>(TargetPosition));
        return agent.transform.position;
    }
}
