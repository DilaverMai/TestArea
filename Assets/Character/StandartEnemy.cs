using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEditor.Rendering.Universal;
using UnityEngine;

namespace Character
{
    public class StandartEnemy : EnemyBase
    {
        [BoxGroup("Modeling")]
        public Transform Model3D;
        
        [Button("Create Model"), BoxGroup("Modeling")]
        public void CreateModel()
        {
            var model = Instantiate(Model3D, transform);
            model.AddComponent<Animator>();
            model.localPosition = Vector3.zero;
            model.localRotation = Quaternion.identity;
        }
        
        [BoxGroup("Systems"),ReadOnly]
        public HealthSystem HealthSystem;
        [BoxGroup("Systems"),ReadOnly]
        public Attacker AttackSystem;
        [BoxGroup("Systems"),ReadOnly]
        public EnemyAnimationSystem AnimationSystemSystem;
        [BoxGroup("Systems"),ReadOnly]
        public CharacterMoveWithNavMeshAndRoute MoveSystem;
        [BoxGroup("Systems"),ReadOnly]
        public PlayerFinder Finder;

        private IUpdater[] _updaters;
        
        public override void OnSpawn()
        {
            Initialize();
            AllRunInitialize();
        }
        
        public override void OnDeath()
        {
            
        }

        private void Update()
        {
            var find = Finder.FindTarget();

            if (find != null)
            {
                MoveSystem.Move(Finder.GetTargetPosition());
                if(MoveSystem.ReachedDestination())
                    AttackSystem.Attack(Finder.FindTarget());
            }
            else MoveSystem.RouteMover();
        }

        private void Initialize()
        {
            Finder = GetComponent<PlayerFinder>();
            HealthSystem = GetComponent<HealthSystem>();
            AttackSystem = GetComponent<Attacker>();
            AnimationSystemSystem = GetComponent<EnemyAnimationSystem>();
            MoveSystem = GetComponent<CharacterMoveWithNavMeshAndRoute>();
            
            HealthSystem.OnDeath.AddListener(() => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Death));
            HealthSystem.OnHit.AddListener(() =>  AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Hit)) ;
            AttackSystem.OnAttack.AddListener(() => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Attack));
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