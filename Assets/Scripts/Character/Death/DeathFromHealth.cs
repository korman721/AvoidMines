public class DeathFromHealth : Death
{
    private Health _health;

    public DeathFromHealth(Health health)
    {
        _health = health;
    }

    protected override void DeathCondition()
    {
        if (_health.CurrentHealth <= 0)
            _isDead= true;
    }
}
