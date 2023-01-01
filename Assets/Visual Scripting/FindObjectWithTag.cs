using Unity.VisualScripting;
using UnityEngine;

public  class FindObjectWithTag: FindCloserObjectUnit
{
    public ValueInput Tag;
    protected override void Definition()
    {
        base.Definition();
        Tag = ValueInput("Tag", "Enemy");
    }

    protected override ControlOutput Finder(Flow flow)
    {
        var tag = flow.GetValue<string>(Tag);
        var closerObjects = GameObject.FindGameObjectsWithTag(tag);
        FoundedObjectTransform =  flow.stack.component.transform.FindCloserGameObjectByTag(closerObjects).transform;
        
        return OutputTrigger;
    }
}