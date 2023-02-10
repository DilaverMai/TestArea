using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Character
{
    [RequireComponent((typeof(NavMeshAgent)))]
    [System.Serializable]
    public class CharacterMoveWithNavMesh:MonoBehaviour, IInitializable, IMoveable
    {
        [BoxGroup("Data")]
        public MoveData MoveData;
        [BoxGroup("Data")]
        public NavMeshAgent NavAgent;
        [BoxGroup("Event")]
        public UnityEvent OnReachedDestination;

        private void Awake()
        {
            NavAgent = GetComponent<NavMeshAgent>();
        }

        public void Initialize()
        {
            NavAgent.speed = MoveData.Speed;
            NavAgent.stoppingDistance = MoveData.StoppingDistance;
            NavAgent.angularSpeed = MoveData.RotationSpeed;
        }

        public virtual void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);
        }
        
        public bool ReachedDestination()
        {
            OnReachedDestination?.Invoke();
            return NavAgent.remainingDistance <= NavAgent.stoppingDistance;
        }
    }
    
}