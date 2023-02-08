namespace Character
{
    public enum EnemyAnimationList
    {
        Idle,
        Walk,
        Attack,
        Hit,
        Death
    }
    
    public abstract class EnemyBase : CharacterBase
    {
        protected virtual void OnHit(){}
    }
}