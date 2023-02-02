using Character;
using UnityEngine.Events;

namespace Character
{
    [System.Serializable]
    public class Attacker : IAttackable,IInitializable
    {
        public AttackerData attackerData;
        public UnityAction OnAttack;
        
        public void Attack(Health health)
        {
            health.TakeDamage(ref health,attackerData.Damage);
            OnAttack?.Invoke();
        }

        public void Initialize()
        {
            
        }
        
    }
}

public interface IAttackable
{
    void Attack(Health health);
}