using System;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class CharacterAnimation<T>: IAnimable<T> where T:Enum
    {
        public Animator Anim;
    
        public void PlayAnimation(T animEnum,int layer = 0,float normalizedTime = 1f,float normalizedTransitionTime = 0.15f)
        {
            if(CheckAnim(ref animEnum))
                Anim.CrossFade(animEnum.ToString(), normalizedTransitionTime, layer, normalizedTime);
            else 
                Anim.CrossFade(animEnum.ToString(), normalizedTransitionTime, layer);
        }

        public bool CheckAnim(ref T animEnum)
        {
            return Anim.GetCurrentAnimatorStateInfo(0).IsName(animEnum.ToString());
        }
    }
}