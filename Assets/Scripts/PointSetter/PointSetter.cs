using UnityEngine;

public class PointSetter 
{
    private Point _pointPrefab;

    public PointSetter(Point pointPrefab, IMovable target)
    {
        _pointPrefab = Object.Instantiate(pointPrefab);

        _pointPrefab.Initialize(target);

        _pointPrefab.gameObject.SetActive(false);
    }

    public void SetPointOnPosition(Vector3 position)
    {
        _pointPrefab.transform.position = position;

        _pointPrefab.gameObject.SetActive(true);
    }
}
