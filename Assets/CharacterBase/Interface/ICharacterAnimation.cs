interface ICharacterAnimation
{
    public void AttackAnimation();
    public void DeathAnimation();
    // public  void IdleAnimation();
    // public void RunAnimation();
    // public void WalkAnimation();
    public void SetSpeed(float speed);
    public void HitAnimation();
    // public void JumpAnimation();
    public void OverrideChangeAnimation(CharacterState state);
}