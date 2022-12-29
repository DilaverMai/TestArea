using UnityEngine;

public class Repeater : DecoratorNode
{
    public Repeater(BehaviourTree tree, BTNode child) : base(tree, child)
    {
        
    }

    public override Results Execute()
    {
        Child.Execute();
        return Results.Running;
    }
}