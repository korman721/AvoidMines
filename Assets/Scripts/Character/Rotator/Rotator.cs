using UnityEngine;

public abstract class Rotator
{
    protected float _rotationSpeed;

    protected Rotator(float rotationSpeed)
    {
        _rotationSpeed = rotationSpeed;
    }

    public void Update(float timeDeltaTime)
    {
        RotateTo(timeDeltaTime);
    }

    public void SetInputDirection(Vector3 inputDirection) => InputDirection = inputDirection;

    protected Vector3 InputDirection { get; private set; }

    public abstract Quaternion Rotation { get; }

    private void RotateTo(float timeDeltaTime)
    {
        if (InputDirection.magnitude < 0.05f)
            return;

        Quaternion lookRotation = Quaternion.LookRotation(InputDirection.normalized);

        float step = _rotationSpeed * timeDeltaTime;

        ApplyRotation(Quaternion.RotateTowards(Rotation, lookRotation, step));
    }

    protected abstract void ApplyRotation(Quaternion rotation);
}