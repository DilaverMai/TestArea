namespace Character
{
    public interface IDamageable
    {
        void TakeDamage(ref HealthSystem healthSystem, int damage);
    }
}