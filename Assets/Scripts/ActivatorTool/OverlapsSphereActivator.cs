using UnityEngine;

public class OverlapsSphereActivator : ActivatorTool
{
    private float _time;
    private float _timeToActivate;

    private float _activateRadius;

    public OverlapsSphereActivator(IActivateble activateble, float timeToActivate, float activateRadius) : base(activateble)
    {
        _timeToActivate = timeToActivate;
        _activateRadius = activateRadius;
    }

    public override void ActivateCondition()
    {
        Collider[] colliders = Physics.OverlapSphere(_activateble.Transform.position, _activateRadius);

        foreach (Collider collider in colliders)
            if (collider.GetComponent<IMovable>() != null)
            {
                _isActivated = true;
                Debug.Log("Mine Activated");
            }

        if (_isActivated)
        {
            _time += Time.deltaTime;

            if (_time > _timeToActivate)
            {
                _activateble.Activate();
                _time = 0;
            }
        }
    }
}