using Cinemachine;
using UnityEngine;

public class Example : MonoBehaviour
{
    [SerializeField] private LayerMask _layerMask;
    [SerializeField] private AgentCharacter _agent;
    [SerializeField] private Camera _camera;
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;

    [SerializeField] private Point _pointPrefab;

    [SerializeField] private Mine[] _mines;

    private CompositeController _agentController;
    private Shooter _shooter;

    private void Awake()
    {
        if (_mines != null)
            foreach (Mine mine in _mines)
                mine.Initialize(_agent, _agent);

        _shooter = new RayShooter(_layerMask, new MoveToPointEffect(_agent, new PointSetter(_pointPrefab, _agent)));

        _agentController = new CompositeController(
            new AlongMovableVelocityRotatableController(_agent, _agent),
            new MoveToPointAgentController(_shooter, _camera, _virtualCamera));

        _agentController.Enable();
    }

    void Update()
    {
        if (_agent.IsDead)
            _agentController.Disable();

        _agentController.Update(Time.deltaTime);
    }
}
