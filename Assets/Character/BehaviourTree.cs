using System.Collections.Generic;

[System.Serializable]
public class BehaviourTree
{
    public List<BehaviourNode> nodes = new List<BehaviourNode>();
    
    public BehaviourTree()
    {
        
    }
}