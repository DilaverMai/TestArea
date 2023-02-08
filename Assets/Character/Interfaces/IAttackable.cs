using System.Collections;
using Character;

public interface IAttackable
{
    void Attack(IDamageable healthSystem);
    IEnumerator AttackCoroutine(IDamageable healthSystem);
}