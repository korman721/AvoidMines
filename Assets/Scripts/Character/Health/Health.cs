public abstract class Health
{
    public int CurrentHealth => _health;

    protected int _health;

    public abstract void TakeDamage(int damage);
}
