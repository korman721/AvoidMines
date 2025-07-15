using UnityEngine;

public abstract class Shooter
{
    protected LayerMask _layerMask;

    protected Shooter(LayerMask layerMask)
    {
        _layerMask = layerMask;
    }

    public abstract void Shoot(Vector3 from, Vector3 to);
}
