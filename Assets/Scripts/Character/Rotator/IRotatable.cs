using UnityEngine;

public interface IRotatable : ITransformable
{
    Quaternion CurrentRotation { get; }

    void SetInputDirectionRotator(Vector3 inputDirection);
}
