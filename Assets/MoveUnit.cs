using Unity.VisualScripting;
using UnityEngine;


[UnitCategory("AI/Move")]
public abstract class MoveUnit : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;
    [DoNotSerialize]
    public ControlOutput outputTrigger;
    
    public ValueInput ThisTransform;
    public ValueInput TargetPosition;
    public ValueInput Speed;
    public ValueInput MinDistance;
    public ValueInput MaxDistance;
    
    [ExecuteAlways]
    [DoNotSerialize]
    public ValueOutput NowPosition{ get; private set; }
    public ValueOutput IsArrive{ get; private set; }
    protected bool _isArrive;
    
    protected virtual void Setup()
    {
        inputTrigger = ControlInput("inputTrigger", Run);
        outputTrigger = ControlOutput("outputTrigger");
        
        MinDistance = ValueInput<float>("MinDistance", 0.1f);
        MaxDistance = ValueInput<float>("MaxDistance", 10f);
        
        Speed = ValueInput("Speed", 1f);
        ThisTransform = ValueInput<Transform>("ThisTransform", null);
        TargetPosition = ValueInput("TargetPosition", Vector3.zero);
        
        NowPosition = ValueOutput("CurrentPosition", MoveToPosition);
        IsArrive = ValueOutput<bool>("IsArrive",(x)=>_isArrive);
    }
    
    protected override void Definition()
    {
        Setup();
    }

    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
        _isArrive = false;

        
        if (instance.GetFlow().GetValue(ThisTransform) == null)
        {
            ThisTransform.SetDefaultValue(instance.component.transform);
        }
    }

    private ControlOutput Run(Flow arg)
    {
        MoveToPosition(arg);
        return outputTrigger;
    }
    
    protected abstract Vector3 MoveToPosition(Flow flow);
    protected virtual void CheckArrive(ref Flow flow,ref float distance)
    {
        _isArrive = distance < flow.GetValue<float>(MaxDistance) & distance < flow.GetValue<float>(MinDistance);
    }
}