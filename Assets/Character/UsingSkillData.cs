using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "AttackerWithSkill", menuName = "Character/AttackerWithSkill", order = 0)]
public class UsingSkillData: ScriptableObject
{
    public GameObject SkillPrefab;
    public UnityEvent OnSkill;
    public string SkillName;
    public float SkillDelay;
    public float SkillRange;
    public float SkillAngle;
}