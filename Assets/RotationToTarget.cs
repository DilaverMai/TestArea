using Unity.VisualScripting;
using UnityEngine;

public class RotationToTarget : RotationToTargetUnit
{
    protected override ControlOutput EnterTriggerAction(Flow arg)
    {
        var distance = Vector3.Distance(arg.stack.component.transform.position, arg.GetValue<Vector3>(Target));
        var rotationDistance = arg.GetValue<float>(RotationSpeed);
        var thisTransform = arg.stack.component.transform;

        if (distance > rotationDistance)
        {
            var direction = arg.GetValue<Vector3>(Target) - thisTransform.position;
            if(arg.GetValue<bool>(YFix))
                direction.y = 0;
            var rotation = Quaternion.LookRotation(direction);
            thisTransform.rotation = Quaternion.Lerp(thisTransform.rotation, rotation,
                arg.GetValue<float>(RotationSpeed) * Time.deltaTime);
        }

        return ExitTrigger;
    }
}