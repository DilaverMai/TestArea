using System.Collections;
using UnityEngine;

interface ICharacterAttackSystem
{
     public Coroutine AttackCoroutine { get; set; }
     public IEnumerator AttackEnumerator(ICharacterHealth target);
     public void AttackTrigger(ICharacterHealth target);
}

public enum CharacterState
{
     Idle,
     Run,
     Walk,
     Jump,
     Attack,
     Death,
     Hit
}