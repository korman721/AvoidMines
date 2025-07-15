public abstract class Death 
{
    public bool IsDead => _isDead;

    protected bool _isDead = false;

    public void UpdateDeathState()
    {
        DeathCondition();
    }

    protected abstract void DeathCondition();
}
