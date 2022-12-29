using System;

public class BTNode
{
    public BTNode Node;
    public BehaviourTree Tree;
    
    public enum Results
    {
        Success,
        Failure,
        Running
    }
    
    public BTNode(BehaviourTree tree)
    {
        Tree = tree;
    }

    public virtual Results Execute()
    {
        return Results.Failure;
    }
}