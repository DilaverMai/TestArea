using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    [System.Serializable]
    public class HealthSystem:MonoBehaviour,  IDamageable,IInitializable
    {
        public UnityAction OnHealthChange;
        public UnityAction OnHit;
        public UnityAction OnDeath;
    
        public int MaxHealth;
        public int CurrentHealth;
        
        public bool isDead => CurrentHealth <= 0;
        
        public void TakeDamage(ref HealthSystem healthSystem, int damage)
        {
            if(isDead) return;
            
            CurrentHealth -= damage;
            OnHealthChange?.Invoke();

            if (isDead)
                OnDeath?.Invoke();
            else
                OnHit?.Invoke();
        }

        public void Initialize()
        {
            CurrentHealth = MaxHealth;
        }
    }
}

public class FindTarget<T>: IUpdater where T: Component
{
    public T FindedTarget;
    public Transform Target;
    
    
    public void OnUpdate()
    {
        
    }
}

public interface IUpdater
{
    void OnUpdate();
}