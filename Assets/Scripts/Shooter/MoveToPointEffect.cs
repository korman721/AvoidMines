using UnityEngine;

public class MoveToPointEffect : IShootEffect
{
    private IMovable _movable;
    private PointSetter _pointSetter;

    public MoveToPointEffect(IMovable movable, PointSetter pointSetter)
    {
        _movable = movable;
        _pointSetter = pointSetter;
    }

    public void Execute(RaycastHit hit)
    {
        Vector3 targetPosition = hit.point;

        _pointSetter.SetPointOnPosition(targetPosition);

        _movable.MoveToPoint(targetPosition);
    }
}
