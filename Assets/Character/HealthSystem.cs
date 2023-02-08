using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    [System.Serializable]
    public class HealthSystem:MonoBehaviour,IDamageable,IInitializable
    {
        public UnityEvent OnHealthChange;
        public UnityEvent OnHit;
        public UnityEvent OnDeath;
    
        public int MaxHealth;
        public int CurrentHealth;
        
        [ReadOnly]
        public CharacterTypes CharacterType;
        
        public bool isDead => CurrentHealth <= 0;
        
        public void TakeDamage(ref IDamageable healthSystem, int damage,ref CharacterTypes characterType)
        {
            Debug.Log(characterType.ToString());
            if(characterType == CharacterType)
                return;
            
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
            CharacterType = GetComponent<CharacterBase>().CharacterType;
        }
    }
}