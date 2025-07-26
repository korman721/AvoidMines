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
<<<<<<< HEAD
        if (Vector3.Distance(_movable.Transform.position, transform.position) <= _radius)
            _damageble.TakeDamage(_damage);
=======
        Collider[] collidersInSphere = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in collidersInSphere)
            if (collider.GetComponent<IDamageble>() != null)
                collider.GetComponent<IDamageble>().TakeDamage(_damage);
>>>>>>> parent of a62c33f (IntermediateCommit)

        gameObject.SetActive(false);
    }

<<<<<<< HEAD
    public override void Initialize(IMovable movable, IDamageble damageble)
    {
        _movable = movable;
        _damageble = damageble;

        _activator = new DistanceActivatorToolWithTimer(this, _movable, _radius, _timeDetonate);
    }

=======
    public override void Initialize()
    {
        _activator = new OverlapsSphereActivator(this, _timeDetonate, _radius);
    }

>>>>>>> parent of a62c33f (IntermediateCommit)
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, _radius);
    }
}
