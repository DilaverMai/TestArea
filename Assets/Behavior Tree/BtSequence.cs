using System.Collections.Generic;

public class BtSequence:BTNode
{
    private List<BTNode> mChildren;
    private int mCurrentChild;
    
    public BtSequence(BehaviourTree tree,BTNode[] nodes):base(tree)
    {
        mChildren = new List<BTNode>(nodes);
        mCurrentChild = 0;
    }
    
    public override Results Execute()
    {
        var result = mChildren[mCurrentChild].Execute();

        if (mCurrentChild >= mChildren.Count)
            return Results.Success;

        if (result == Results.Success)
        {
            mCurrentChild++;
            if (mCurrentChild >= mChildren.Count)
            {
                mCurrentChild = 0;
                return Results.Success;
            }
            
            return Results.Running;
        }
        if(result == Results.Failure)
            mCurrentChild = 0;
        
        return result;
    }
}