using UnityEngine;

public class RayShooter : Shooter
{
    private IShootEffect _shootEffect;

    public RayShooter(LayerMask layerMask, IShootEffect shootEffect) : base(layerMask)
    {
        _shootEffect = shootEffect;
    }

    public override void Shoot(Vector3 from, Vector3 to)
    {
        Ray ray = new Ray(from, to);

        if (Physics.Raycast(ray, out RaycastHit hit, _layerMask))
            if (hit.collider.gameObject.layer == (int)Mathf.Log((int)_layerMask, 2))
                _shootEffect.Execute(hit);
        
    }
}
