public class DecoratorNode : BTNode
{
    public BTNode Child;
    
    public DecoratorNode(BehaviourTree tree, BTNode child) : base(tree)
    {
        Child = child;
    }
}