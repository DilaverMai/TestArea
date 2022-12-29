using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourTree:MonoBehaviour
{
    public Dictionary<string,object> mBlackboard;
    public BTNode Root => mRoot;

    private BTNode mRoot;
    private bool mRunning;
    private Coroutine mCoroutine;

    private void Start()
    {
        mBlackboard = new Dictionary<string, object>();
        mBlackboard.Add("Player", GameObject.Find("Player"));
        mBlackboard.Add("FindPosition", new Vector3(Random.Range(-10, 10f), 0, Random.Range(-10, 10f)));
        mRunning = false;


        mRoot = new Repeater(this,new BtSequence(this,new BTNode[]{new TestNode(this)}));
        //mRoot = new BtSequence(this, new BTNode[] { new TestNode(this) });
        //mRoot = new Repeater(this, new TestNode(this));
    }

    private void Update()
    {
        if (!mRunning)
        {
            mCoroutine = StartCoroutine(BehaviourRunner());
            mRunning = true;
        }
    }

    private IEnumerator BehaviourRunner()
    {
        BTNode.Results result = Root.Execute();
        
        while (result == BTNode.Results.Running)
        {
            yield return null;
            result = Root.Execute();
        }
        
        Debug.Log("Behaviour Tree Finished: " + result.ToString());
    }
}