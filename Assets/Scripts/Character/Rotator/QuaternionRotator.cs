using UnityEngine;

public class QuaternionRotator : Rotator
{
    private Transform _transform;

    private float _rotationSpeed;

    public QuaternionRotator(Transform transform, float rotationSpeed)
    {
        _transform = transform;
        _rotationSpeed = rotationSpeed;
    }

    protected override void RotateTo(float timeDeltaTime)
    {
        if (InputDirection.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(InputDirection.normalized);

        float step = _rotationSpeed * timeDeltaTime;

        _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
    }
}
