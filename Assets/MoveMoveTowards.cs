using Unity.VisualScripting;
using UnityEngine;

[TypeIcon(typeof(Transform))]
public class MoveMoveTowards : MoveUnit
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
            
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, targetPosition, speed * Time.fixedDeltaTime);

        return thisTransform.position;
    }
}