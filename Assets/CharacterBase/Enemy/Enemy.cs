using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour, ICharacter
{
    private ICharacterHealth _characterHealth;
    private ICharacterMovement _characterMovement;
    private ICharacterAttackSystem _characterAttackSystem;

    #region Events

    public UnityEvent OnDeath;
    public UnityEvent OnHit;
    public UnityEvent OnAttack;

    #endregion

    protected virtual void Awake()
    {
        _characterHealth = GetComponent<ICharacterHealth>();
        _characterMovement = GetComponent<ICharacterMovement>();
        _characterAttackSystem = GetComponent<ICharacterAttackSystem>();
    }

    public virtual void Checker()
    {
        
    }

    protected virtual void Update()
    {
        Checker();
    }
}