using UnityEngine;

public class MineWithDistanceTimerActivator : Mine
{
    [SerializeField] private float _radius;
    [SerializeField] private float _timeDetonate;

    [SerializeField] private int _damage;

    private IMovable _movable;
    private IDamageble _damageble;

    private void Update()
    {
        if (_activator == null)
            return;

        _activator.ActivateCondition();
    }

    public override void Activate()
    {
        if (Vector3.Distance(_movable.Transform.position, transform.position) <= _radius)
            _damageble.TakeDamage(_damage);

        gameObject.SetActive(false);
    }

    public override void Initialize(IMovable movable, IDamageble damageble)
    {
        _movable = movable;
        _damageble = damageble;

        _activator = new DistanceActivatorToolWithTimer(this, _movable, _radius, _timeDetonate);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
