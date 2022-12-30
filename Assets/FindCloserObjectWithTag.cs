using Unity.VisualScripting;
using UnityEngine;

public class FindCloserObjectWithTag : Unit
{
    public ControlInput inputTrigger;
    public ControlOutput outputTrigger;
    
    public ValueOutput CloserObjectt;
    public ValueInput ThisTransform;
    
    public ControlInput findCloserObject;
    public  ControlOutput closerObjectFound; 
    
    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", Deneme);
        ThisTransform = ValueInput<Transform>("ThisTransform",default);
    }

    public override void Instantiate(GraphReference instance)
    {
        base.Instantiate(instance);
       
        var _flow = Flow.New(instance);

        if (_flow.GetValue<Transform>(ThisTransform) == null)
            ThisTransform.SetDefaultValue(_flow.stack.component.transform);
    }
    
    private ControlOutput Deneme(Flow arg)
    {
        GetCloserObject(arg.stack.component.transform);
        return null;
    }

    private GameObject GetCloserObject(Transform tt)
    {
        Debug.Log(tt.name);
        return null;
    }
}