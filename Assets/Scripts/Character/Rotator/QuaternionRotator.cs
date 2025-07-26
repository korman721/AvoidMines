using UnityEngine;

public class QuaternionRotator : Rotator
{
    private Transform _transform;

    public QuaternionRotator(float rotationSpeed, Transform transform) : base(rotationSpeed)
    {
        _transform= transform;
    }

    public override Quaternion Rotation => _transform.rotation;

    protected override void ApplyRotation(Quaternion rotation) => _transform.rotation = rotation;
}
