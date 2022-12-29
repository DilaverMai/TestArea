using System.Collections.Generic;

public class BtComposite : BTNode
{
    public List<BTNode> Children { get; private set; }

    public BtComposite(BehaviourTree tree,BTNode[] nodes) : base(tree)
    {
        Children = new List<BTNode>(nodes);
    }
}