using System.Collections;
using UnityEngine;

public class EnemyAttackSystem:MonoBehaviour, ICharacterAttackSystem
{
    public int AttackDamage;
    public float AttackSpeed;
    public float AttackRange;
    public Coroutine AttackCoroutine { get; set; }

    public IEnumerator AttackEnumerator(ICharacterHealth target)
    {
        yield return new WaitForSeconds(AttackSpeed);
        target.TakeDamage(AttackDamage);
    }

    public void AttackTrigger(ICharacterHealth target)
    {
        if (AttackCoroutine != null)
            StopCoroutine(AttackCoroutine);
        else AttackCoroutine = StartCoroutine(AttackEnumerator(target));
    }
}