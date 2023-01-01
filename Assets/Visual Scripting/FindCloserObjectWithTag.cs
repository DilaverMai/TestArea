using Unity.VisualScripting;
using UnityEngine;

[UnitCategory("Finders/Mono")]
public abstract class FindCloserObjectUnit : Unit
{
    public ControlInput InputTrigger;
    public ControlOutput OutputTrigger;

    public ValueOutput FindedObject;
    public ValueOutput FindedObjectVector;
    
    protected  Transform FoundedObjectTransform;
    
    protected override void Definition()
    {
        InputTrigger = ControlInput("inputTrigger", Finder);
        OutputTrigger = ControlOutput("outputTrigger");
        
        FindedObject = ValueOutput<Transform>("FindedObject",(x)=> FoundedObjectTransform);
        FindedObjectVector = ValueOutput<Vector3>("FindedObjectVector",GetVector);
    }

    protected Vector3 GetVector(Flow arg)
    {
        return FoundedObjectTransform == null ? default : FoundedObjectTransform.position;
    }

    protected abstract ControlOutput Finder(Flow arg);

}