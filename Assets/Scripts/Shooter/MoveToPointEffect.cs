using UnityEngine;
using UnityEngine.AI;

public class MoveToPointEffect : IShootEffect
{
    private IMovable _movable;
    private PointSetter _pointSetter;

    private NavMeshPath _path;

    public MoveToPointEffect(IMovable movable, PointSetter pointSetter)
    {
        _movable = movable;
        _pointSetter = pointSetter;

        _path = new NavMeshPath();
    }

    public void Execute(RaycastHit hit)
    {
        Vector3 targetPosition = hit.point;

        _pointSetter.SetPointOnPosition(targetPosition);

        _movable.MoveToPoint(targetPosition);
    }
}
