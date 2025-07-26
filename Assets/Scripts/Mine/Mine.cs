using UnityEngine;

public abstract class Mine : MonoBehaviour, IActivateble
{
    protected ActivatorTool _activator;

    public Transform Transform => transform;

    public abstract void Activate();

<<<<<<< HEAD
    public abstract void Initialize(IMovable movable, IDamageble damageble);
=======
    public abstract void Initialize();
>>>>>>> parent of a62c33f (IntermediateCommit)
}