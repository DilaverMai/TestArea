using Character;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    [System.Serializable]
    public class Attacker :MonoBehaviour, IAttackable,IInitializable
    {
        public AttackerData attackerData;
        public UnityAction OnAttack;
        
        public void Attack(HealthSystem healthSystem)
        {
            healthSystem.TakeDamage(ref healthSystem,attackerData.Damage);
            OnAttack?.Invoke();
        }

        public void Initialize()
        {
            
        }
        
    }
}

public interface IAttackable
{
    void Attack(HealthSystem healthSystem);
}