using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FindObjectInList : FindCloserObjectUnit
{
    public ValueInput ObjectList;
    
    protected override void Definition()
    {
        base.Definition();
        ObjectList = ValueInput<List<MonoBehaviour>>("ObjectList", null);
    }
    protected override ControlOutput Finder(Flow arg)
    {
        arg.stack.component.transform.FindCloserObjectGeneric<MonoBehaviour>(arg.GetValue<List<MonoBehaviour>>(ObjectList));
        return OutputTrigger;
    }
}