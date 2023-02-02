using UnityEngine;
using UnityEngine.AI;

namespace Character
{
    [System.Serializable]
    public class CharacterMoveWithNavMesh: IInitializable,IMoveable
    {
        public MoveData MoveData;
        public NavMeshAgent NavAgent;
    
        public void Initialize()
        {
            NavAgent.speed = MoveData.Speed;
        }

        public void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);
        }

        public bool ReachedDestination()
        {
            return NavAgent.remainingDistance <= NavAgent.stoppingDistance;
        }
    }
}