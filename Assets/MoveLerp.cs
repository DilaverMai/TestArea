using Unity.VisualScripting;
using UnityEngine;

[UnitTitle("Move With Lerp")]
[TypeIcon(typeof(Transform))]
public class MoveLerp : MoveUnit
{
    protected override Vector3 MoveToPosition(Flow flow)
    {
        var thisTransform = flow.GetValue<Transform>(ThisTransform);
        var speed = flow.GetValue<float>(Speed);
        var targetPosition = flow.GetValue<Vector3>(TargetPosition);
        var distance = Vector3.Distance(thisTransform.position, targetPosition);
        
        CheckArrive(ref flow,ref distance);
        if(distance > flow.GetValue<float>(MaxDistance) || distance < flow.GetValue<float>(MinDistance))
            return thisTransform.position;
            
        thisTransform.position = Vector3.Lerp(thisTransform.position, targetPosition, speed * Time.fixedDeltaTime);

        return thisTransform.position;
    }
}

public abstract class LookAtTarget: Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;
    [DoNotSerialize]
    public ControlOutput outputTrigger;
    
    public ValueInput TargetPosition;
    public ValueInput Speed;
    public ValueInput AlwaysLook;
    public ValueInput LookDistance;
    
    protected override void Definition()
    {
        
    }
}