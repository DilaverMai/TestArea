using System;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour, ICharacterAnimation
{
    private Animator _animator;
    
    private static readonly int Speed = Animator.StringToHash("Speed");
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private static readonly int IsDead = Animator.StringToHash("IsDead");
    private static readonly int Hit = Animator.StringToHash("Hit");
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void AttackAnimation()
    {
       _animator.SetTrigger(IsAttacking);
    }

    public void DeathAnimation()
    {
        _animator.SetTrigger(IsDead);
        SetSpeed(0);
    }

    public void SetSpeed(float speed)
    {
        _animator.SetFloat(Speed, speed);
    }

    public void HitAnimation()
    {
        _animator.SetTrigger(Hit);
    }

    public void OverrideChangeAnimation(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Idle:
                SetSpeed(0);
                break;
            case CharacterState.Run:
                SetSpeed(1);
                break;
            case CharacterState.Walk:
                SetSpeed(.5f);
                break;
            // case CharacterState.Jump:
            //     break;
            case CharacterState.Attack:
                AttackAnimation();
                break;
            case CharacterState.Death:
                DeathAnimation();
                break;
            case CharacterState.Hit:
                
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
}