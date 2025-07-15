using UnityEngine;

public class DistanceActivatorToolWithTimer : DistanceActivatorTool
{
    private float _time;
    private float _timeToActivate;

    public DistanceActivatorToolWithTimer(IActivateble activateble, IMovable movable, float activateRadius, float timeToActivate) : base(activateble, movable, activateRadius)
    {
        _timeToActivate = timeToActivate;
    }

    public override void ActivateCondition()
    {
        if (Vector3.Distance(_movable.Transform.position, _activateble.Transform.position) <= _activateRadius)
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
