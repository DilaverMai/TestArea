using Unity.VisualScripting;
using UnityEngine;

public class DistanceCheck : Unit
{
    public ValueInput TargetPos;
    public ValueOutput InRange;
    public ValueInput MinDistance;
    public ValueInput MaxDistance;
    
    public ControlInput Trigger;
    public ControlOutput TrueController;
    public ControlOutput FalseController;
    
    protected override void Definition()
    {
        Trigger = ControlInput("Trigger", Triggered);
        
        TargetPos = ValueInput<Vector3>("TargetPos");
        // InRange = ValueOutput<bool>("InRange", InRangeFunc);
        MaxDistance = ValueInput<float>("MaxDistance", 10f);
        MinDistance = ValueInput<float>("MinDistance",1f);
        
        TrueController = ControlOutput("True");
        FalseController = ControlOutput("False");           
    }

    private ControlOutput Triggered(Flow arg)
    {
        return InRangeFunc(ref arg) ? TrueController : FalseController;
    }

    private bool InRangeFunc(ref Flow arg)
    {
        var targetPos = arg.GetValue<Vector3>(TargetPos);
        var minDistance = arg.GetValue<float>(MinDistance);
        var maxDistance = arg.GetValue<float>(MaxDistance);
        
        var distance = Vector3.Distance(targetPos,arg.stack.component.transform.position);
        return distance > minDistance && distance < maxDistance;;      
    }
}