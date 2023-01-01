using Unity.VisualScripting;
using UnityEngine;

[UnitCategory("AI/Rotation")]
public abstract class RotationToTargetUnit : Unit
{
    public ControlInput EnterTrigger;
    public ControlOutput ExitTrigger;

    public ValueInput Target;
    public ValueInput RotationSpeed;
    public ValueInput RotationOffset;
    public ValueInput RotationDistance;
    public ValueInput CurrentDistance;
    public ValueInput YFix;

    protected bool _isRotating;

    protected override void Definition()
    {
        Setup();
    }

    protected virtual void Setup()
    {
        EnterTrigger = ControlInput(nameof(EnterTrigger), EnterTriggerAction);
        ExitTrigger = ControlOutput(nameof(ExitTrigger));

        Target = ValueInput<Vector3>("Target");
        RotationSpeed = ValueInput<float>("RotationSpeed",5);
        RotationOffset = ValueInput<Vector3>("RotationOffset",Vector3.zero);
        RotationDistance = ValueInput<float>("RotationDistance",20);
        CurrentDistance = ValueInput<float>("CurrentDistance");
        YFix = ValueInput<bool>("YFix",true);
    }
    protected abstract ControlOutput EnterTriggerAction(Flow arg);
}