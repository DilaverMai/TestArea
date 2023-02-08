using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    [System.Serializable]
    public class Attacker :MonoBehaviour, IAttackable,IInitializable
    {
        [ReadOnly]
        public CharacterTypes CharacterType;
        [ShowInInspector,ReadOnly]
        private Coroutine _attackCoroutine;
        
        public AttackerData attackerData;
        public UnityEvent OnAttack;
        
        
        public void Attack(IDamageable healthSystem)
        {
            if(_attackCoroutine != null) return;
           _attackCoroutine = StartCoroutine(AttackCoroutine(healthSystem));
        }
        public IEnumerator AttackCoroutine(IDamageable healthSystem)
        {
            healthSystem.TakeDamage(ref healthSystem,attackerData.Damage,ref CharacterType);
            OnAttack?.Invoke();
            yield return new WaitForSeconds(attackerData.AttackDelay);
            _attackCoroutine = null;
        }

        public void Initialize()
        {
            CharacterType = GetComponent<CharacterBase>().CharacterType;
        }
        
    }
}