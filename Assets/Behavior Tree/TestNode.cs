using Unity.VisualScripting;
using UnityEngine;

public class TestNode : BTNode
{
    private Vector3 randomPosition;
    private float timer;
    public TestNode(BehaviourTree tree) : base(tree)
    {
        randomPosition = Vector3.zero;
        FindNextPosition();
    }

    public bool FindNextPosition()
    {
        Debug.Log("Finding next position");
        
        object obj;
        bool found = Tree.mBlackboard.TryGetValue("FindPosition", out obj);

        if (found)
            randomPosition = new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10));
        else Debug.Log("No position found");
        Debug.Log(randomPosition + " Distance: " + Vector3.Distance(Tree.transform.position,randomPosition));
        return found;
    }

    public override Results Execute()
    {
        if (Vector3.Distance(Tree.transform.position,randomPosition) < 0.1f)
        {
            Debug.Log(randomPosition);
            if (FindNextPosition()) 
                return Results.Success;
            
            Debug.Log("No position found");
            return Results.Failure;
        }
        
        Tree.transform.position = Vector3.Lerp(Tree.transform.position, randomPosition, 1f * Time.deltaTime);
        return Results.Running;
        
    }
}