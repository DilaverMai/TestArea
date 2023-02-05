using UnityEditor.Rendering.Universal;
using UnityEngine;

namespace Character
{
    public class StandartEnemy : EnemyBase,IInitializabler
    {
        public HealthSystem HealthSystem;
        public Attacker AttackSystem;
        public EnemyAnimationSystem AnimationSystemSystem;
        public CharacterMoveWithNavMesh MoveSystem;
        
        public override void OnSpawn()
        {
            HealthSystem.Initialize();
            AttackSystem.Initialize();
            MoveSystem.Initialize();
            Initialize();
        }
        
        public override void OnDeath()
        {
            
        }

        public void Initialize()
        {
            HealthSystem = GetComponent<HealthSystem>();
            AttackSystem = GetComponent<Attacker>();
            AnimationSystemSystem = GetComponent<EnemyAnimationSystem>();
            MoveSystem = GetComponent<CharacterMoveWithNavMesh>();
            
            HealthSystem.OnDeath += () => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Death);
            HealthSystem.OnHit += () => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Hit);
            AttackSystem.OnAttack += () => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Attack);
        }

        public void AllRunInitialize()
        {
            var componentsInChildren = GetComponentsInChildren<IInitializable>();
            
            foreach (var init in componentsInChildren)
            {
                init.Initialize();
            }
        }
        
    }
    
}