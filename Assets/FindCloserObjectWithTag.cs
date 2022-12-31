using Unity.VisualScripting;
using UnityEngine;

[UnitCategory("Finders/Mono")]
public abstract class FindCloserObjectWithTagUnit : Unit
{
    public ControlInput inputTrigger;
    public ControlOutput outputTrigger;

    public ValueInput Tag;
    
    public ValueOutput CloserObjectt;
    
    public ControlInput findCloserObject;
    public  ControlOutput closerObjectFound; 
    
    protected override void Definition()
    {
        inputTrigger = ControlInput("inputTrigger", Finder);
        Tag = ValueInput("Tag", "Enemy");
    }
    
    private ControlOutput Finder(Flow arg)
    {
        var thisTransform = arg.stack.gameObject.transform;
        var enemies = GameObject.FindGameObjectsWithTag(arg.GetValue<string>(Tag));
        thisTransform.FindCloserGameObjectByTag(enemies);
        
        return outputTrigger;
    }
    
}