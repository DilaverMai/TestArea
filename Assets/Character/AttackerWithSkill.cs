using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Character
{
    public class AttackerWithSkill : Attacker
    {
        public UsingSkillData[] usingSkillData;
        public List<Skill>

        public override void OnDrawGizmos()
        {
            base.OnDrawGizmos();
        
            if(usingSkillData.Length == 0) return;
      
        
            Handles.color = Color.magenta;
            foreach (var skill in usingSkillData)
            {
                var position = transform.position;
                var forward = transform.forward;
            
                Handles.Label(position + (forward * skill.SkillRange) * .5f, skill.SkillName, EditorStyles.boldLabel);
                Handles.DrawWireArc(position, Vector3.up, forward, skill.SkillAngle, skill.SkillRange, 7.5f);
                Handles.DrawWireArc(position, Vector3.up, forward, -skill.SkillAngle, skill.SkillRange, 7.5f);
            }
        }
    }

    public class Skill
    {
        public enum SkillStat
        {
            IsUsing,
            IsCoolTime,
        }
        
        private UsingSkillData skillData;
        private SkillStat _skillStat;
        
        public Skill(UsingSkillData skillData)
        {
            this.skillData = skillData;
        }
        
        public async void UseSkill()
        {
            if(_skillStat == SkillStat.IsCoolTime) return;

            while (true)
            {
                
            }
        }
        
        
        
    }
}