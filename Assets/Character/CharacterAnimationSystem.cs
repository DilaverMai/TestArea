using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public abstract class CharacterAnimationSystem<T>: IAnimable<T> where T:Enum
    {
        public Animator Anim;
        public ParticleAnim<T>[] ParticleAnims;
        
        public void PlayParticle(T animEnum)
        {
            foreach (var particleAnim in ParticleAnims)
            {
                if (particleAnim.AnimEnum.Equals(animEnum))
                {
                    particleAnim.SpawnParticle();
                }
            }
        }
        
        public void PlayAnimation(T animEnum,int layer = 0,float normalizedTime = 1f,float normalizedTransitionTime = 0.15f)
        {
            if(CheckAnim(ref animEnum))
                Anim.CrossFade(animEnum.ToString(), normalizedTransitionTime, layer, normalizedTime);
            else 
                Anim.CrossFade(animEnum.ToString(), normalizedTransitionTime, layer);
            
            PlayParticle(animEnum);
        }

        public bool CheckAnim(ref T animEnum)
        {
            return Anim.GetCurrentAnimatorStateInfo(0).IsName(animEnum.ToString());
        }
    }
}