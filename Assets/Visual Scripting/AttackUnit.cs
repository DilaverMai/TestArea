using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class AttackToTarget : Unit,ICharacterAttackSystemUnit
{
    private TaskStatus _taskStatus;
    
    public ValueInput TargetHealthSystem;
    public ValueInput AttackDamage;
    public ValueInput AttackSpeed;
    public ValueInput AttackRange;

    public ControlInput TheAttackTrigger;
    public ControlOutput TheAttackTriggered;
    private bool IsAttacking;
    protected override void Definition()
    {
        TargetHealthSystem = ValueInput<Transform>("TargetHealthSystem");
        
        TheAttackTrigger = ControlInput("TheAttackTrigger",AttackTrigger);
        
        AttackDamage = ValueInput<int>("AttackDamage",1);
        AttackSpeed = ValueInput<float>("AttackSpeed",1.25f);
        AttackRange = ValueInput<float>("AttackRange",20f);
    }

    private Task AttackTask;
    
    public ControlOutput AttackTrigger(Flow arg)
    {
        if(IsAttacking)
            return null;
        
        Debug.Log("Attack Triggered");
        var target = arg.GetValue<Transform>(TargetHealthSystem).GetComponent<ICharacterHealth>();
        AttackEnumerator(arg,target);
        
        return null;
    }

    public async void AttackEnumerator(Flow flow, ICharacterHealth target)
    {        
        Debug.Log("Attack Enumerator Started");
        IsAttacking = true;
        var attackDamage = flow.GetValue<int>(AttackDamage);
        var attackSpeed = flow.GetValue<float>(AttackSpeed);
        
        if(Application.isPlaying)
            await Task.Delay(1000);
        
        Debug.Log("Attack Finished");
        // if(!Application.isPlaying)
        //     return;
        target.TakeDamage(attackDamage);
        IsAttacking = false;
    }
}

public interface ICharacterAttackSystemUnit
{
    public ControlOutput AttackTrigger(Flow arg);
    public void AttackEnumerator(Flow flow, ICharacterHealth target);
}

public static class TaskExtensions
{
    public static async Task DelayControl(this Task task, int milliseconds)
    {
        if(Application.isPlaying)
            await Task.Delay(milliseconds);
    }
}