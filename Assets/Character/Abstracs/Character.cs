using UnityEngine;

namespace Character
{
    public enum CharacterTypes
    {
        Friendly,
        Enemy
    }
    public abstract class CharacterBase : MonoBehaviour
    {
        public CharacterTypes CharacterType;
        
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