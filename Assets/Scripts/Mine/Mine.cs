using UnityEngine;

public abstract class Mine : MonoBehaviour, IActivateble
{
    protected AudioSource _explosionSound;

    protected ActivatorTool _activator;

    public Transform Transform => transform;

    public abstract void Activate();

    public abstract void Initialize(AudioSource exlosion);
}