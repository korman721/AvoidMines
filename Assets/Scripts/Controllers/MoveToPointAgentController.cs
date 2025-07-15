using Cinemachine;
using UnityEngine;

public class MoveToPointAgentController : Controller
{
    private const int LeftButtonKey = 0;

    private Shooter _shooter;
    private Camera _camera;
    private CinemachineVirtualCamera _virtualCamera;

    public MoveToPointAgentController(
        Shooter shooter,
        Camera camera, 
        CinemachineVirtualCamera virtualCamera)
    {
        _shooter = shooter;
        _camera = camera;
        _virtualCamera = virtualCamera;
    }

    protected override void UpdateLogic(float timeDeltaTime)
    {
        if (Input.GetMouseButtonDown(LeftButtonKey))
            Shoot();
    }

    private void Shoot()
    {
        _camera.transform.position = _virtualCamera.transform.position;
        _camera.transform.rotation = _virtualCamera.transform.rotation;

        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        _shooter.Shoot(ray.origin, ray.direction);
    }
}
