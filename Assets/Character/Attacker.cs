using System.Collections;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    [System.Serializable]
    public class Attacker :MonoBehaviour, IAttackable,IInitializable
    {
        [BoxGroup("Current Data")]
        public AttackerData attackerData;
        [BoxGroup("Events")]
        public UnityEvent OnAttack;
        
        [BoxGroup("Data"),ReadOnly]
        public CharacterTypes CharacterType;
        [BoxGroup("Data"),ShowInInspector,ReadOnly]
        private Coroutine _attackCoroutine;

        private WaitForSeconds attackDelay;
        
        public void Attack(IDamageable healthSystem,float targetDistance = 0)
        {
            if(_attackCoroutine != null) return;
            if(targetDistance > attackerData.AttackRange) return;
            _attackCoroutine = StartCoroutine(AttackCoroutine(healthSystem));
        }
        
        public IEnumerator AttackCoroutine(IDamageable healthSystem)
        {
            healthSystem.TakeDamage(ref healthSystem,attackerData.Damage,ref CharacterType);
            OnAttack?.Invoke();
            yield return attackDelay;
            _attackCoroutine = null;
        }

        public void Initialize()
        {
            CharacterType = GetComponent<CharacterBase>().CharacterType;
            attackDelay = new WaitForSeconds(attackerData.AttackDelay);
        }

        private void OnDrawGizmos()
        {
            Handles.color = Color.red;
            Handles.DrawWireDisc(transform.position, Vector3.up, attackerData.AttackRange, 10f);
        }

    }
}