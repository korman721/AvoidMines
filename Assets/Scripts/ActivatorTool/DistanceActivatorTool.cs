using UnityEngine;

public class DistanceActivatorTool : ActivatorTool
{
    protected IMovable _movable;
    protected float _activateRadius;

    public DistanceActivatorTool(IActivateble activateble, IMovable movable, float activateRadius) : base(activateble)
    {
        _movable = movable;
        _activateRadius = activateRadius;
    }

    public override void ActivateCondition()
    {
        if (Vector3.Distance(_movable.Transform.position, _activateble.Transform.position) >= _activateRadius)
            return;

        _activateble.Activate();
    }
}
