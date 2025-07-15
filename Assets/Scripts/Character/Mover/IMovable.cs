using UnityEngine;

public interface IMovable : ITransformable
{
    Vector3 CurrentVelocity { get; }

    void MoveToPoint(Vector3 position);
}
