using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class FindObjectExtensions
{
    public static T FindCloserObjectGeneric<T>(this Transform transform,IEnumerable<T> list) where T: MonoBehaviour
    {
        return list.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
    }
    
    public static GameObject FindCloserGameObjectByTag(this Transform transform,IEnumerable<GameObject> list)
    {
        return list.OrderBy(x => Vector3.Distance(transform.position, x.transform.position)).FirstOrDefault();
    }
    
}