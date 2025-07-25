using UnityEngine;

public abstract class Rotator
{
    protected Vector3 InputDirection { get; private set; }

    public void Update(float timeDeltaTime)
    {
        RotateTo(timeDeltaTime);
    }

    public void SetInputDirection(Vector3 inputDirection) => InputDirection = inputDirection;

    public Quaternion GetCurrentRotation(Transform transform) => transform.rotation;

    protected abstract void RotateTo(float timeDeltaTime);
}
