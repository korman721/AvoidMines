using UnityEngine;

public class CommonHealth : Health
{
    public CommonHealth(int maxHealth)
    {
        _health = maxHealth;
    }

    public override void TakeDamage(int damage)
    {
        if (_health <= 0)
            _health = 0;

        _health -= damage;

        Debug.Log($"Current Health: {_health}");
    }
}
