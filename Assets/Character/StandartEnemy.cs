namespace Character
{
    public class StandartEnemy : EnemyBase
    {
        public Health HealthSystem;
        public Attacker AttackSystem;
        public CharacterAnimation<EnemyAnimationList> AnimationSystem;
        public CharacterMoveWithNavMesh MoveSystem;
        
        public override void OnSpawn()
        {
            HealthSystem.Initialize();

            HealthSystem.OnDeath += () => AnimationSystem.PlayAnimation(EnemyAnimationList.Death);
        }
        
        public override void OnDeath()
        {
            HealthSystem.OnDeath -= () => AnimationSystem.PlayAnimation(EnemyAnimationList.Death);
        }
    }
}