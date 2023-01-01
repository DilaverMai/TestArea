using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour, ICharacterHealth
{
    public int _health;
    public int _maxHealth;
    public int CurrentHealth => _health;
    
    private Enemy _character;

    private void Awake()
    {
       // _character = GetComponent<Enemy>();
    }

    private void OnEnable()
    {
        _health = _maxHealth;
        //_character.OnDeath.AddListener(Die);
    }

    private void OnDisable()
    {
       // _character.OnDeath.RemoveListener(Die);
    }

    public void TakeDamage(int damage)
    {
        if(_health <= 0) return;
        _health -= damage;
        
        // if (_health > 0)
        //     _character.OnHit.Invoke();
        // else if (_health <= 0)
        //     _character.OnDeath.Invoke();
    }

    public void GetHeal(int heal)
    {
        _health += heal;
        if (_health > _maxHealth)
            _health = _maxHealth;
    }

    public void Die()
    {
        _health = 0;
    }
}
