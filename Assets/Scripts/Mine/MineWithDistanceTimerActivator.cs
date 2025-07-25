using UnityEngine;

public class MineWithDistanceTimerActivator : Mine
{
    [SerializeField] private float _radius;
    [SerializeField] private float _timeDetonate;

    [SerializeField] private int _damage;

    private void Update()
    {
        if (_activator == null)
            return;

        _activator.ActivateCondition();
    }

    public override void Activate()
    {
        Collider[] collidersInSphere = Physics.OverlapSphere(transform.position, _radius);

        foreach (Collider collider in collidersInSphere)
            if (collider.GetComponent<IDamageble>() != null)
                collider.GetComponent<IDamageble>().TakeDamage(_damage);

        _explosionSound.Play();

        gameObject.SetActive(false);
    }

    public override void Initialize(AudioSource exlosion)
    {   
        _activator = new OverlapsSphereActivator(this, _timeDetonate, _radius, this);

        _explosionSound = exlosion;
    }
}
