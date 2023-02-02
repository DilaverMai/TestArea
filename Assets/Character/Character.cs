using UnityEngine;

namespace Character
{
    public abstract class CharacterBase : MonoBehaviour
    {
        protected virtual void OnEnable()
        {
            OnSpawn();
        }
        
        protected virtual void OnDisable()
        {
            OnDeath();
        }

        public abstract void OnDeath();
        public abstract void OnSpawn();
    }
}