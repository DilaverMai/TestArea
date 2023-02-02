namespace Character
{
    public interface IDamageable
    {
        void TakeDamage(ref Health health, int damage);
    }
}