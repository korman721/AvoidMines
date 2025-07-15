using UnityEngine;

public class Point : MonoBehaviour, IActivateble
{
    [SerializeField] private float _radius;

    private ActivatorTool _activator;

    public Transform Transform => transform;

    public void Initialize(IMovable movable)
    {
        _activator = new DistanceActivatorTool(this, movable, _radius);
    }

    private void Update()
    {
        if (_activator == null)
            return;

        _activator.ActivateCondition();
    }

    public void Activate() => gameObject.SetActive(false);
}
