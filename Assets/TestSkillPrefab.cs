using Character;
using UnityEngine;

public class TestSkillPrefab : MonoBehaviour
{
    public void Spawn()
    {
        Instantiate(this);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IMoveable>(out var moveable))
        {
            moveable.JumpBack(transform.position);
        }
    }
}
