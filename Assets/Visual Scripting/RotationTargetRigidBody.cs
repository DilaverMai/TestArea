using Unity.VisualScripting;
using UnityEngine;

public class RotationTargetRigidBody : RotationToTargetUnit
{
    private Rigidbody _rigidBody;

    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
        _rigidBody = instance.gameObject.GetComponent<Rigidbody>();
    }

    protected override ControlOutput EnterTriggerAction(Flow arg)
    {
        var rotationDistance = arg.GetValue<float>(RotationDistance);

        if (arg.GetValue<float>(CurrentDistance) > rotationDistance & rotationDistance > 0)
            return null;
        
        var thisTransform = arg.stack.gameObject.transform;
        var target = arg.GetValue<Vector3>(Target);
        var rotationSpeed = arg.GetValue<float>(RotationSpeed);
        var rotationOffset = arg.GetValue<Vector3>(RotationOffset);
        
        var targetRotation = Quaternion.LookRotation(target - thisTransform.position + rotationOffset);
        _rigidBody.MoveRotation(Quaternion.RotateTowards(thisTransform.rotation, targetRotation, rotationSpeed * Time.deltaTime));

        return null;
    }
}