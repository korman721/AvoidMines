using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IRotatable, IDamageble, IMovable, ICollectable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _jumpSpeed;

    [SerializeField] private int _maxHealth;

    [SerializeField] private int _coinsToWin;

    [SerializeField] private AnimationCurve _animCurve;

    private NavMeshAgent _agent;

    private AgentMover _mover;
    private AgentJumper _jumper;
    private Rotator _rotator;
    private Health _health;
    private Death _death;
    private Wallet _wallet;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Quaternion CurrentRotation => _rotator.Rotation;

    public bool IsDead => _death.IsDead;

    public int Health => _health.CurrentHealth;

    public Transform Transform => transform;

    public bool InProcessJump => _jumper.InProcess;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _mover = new AgentMover(_agent, _moveSpeed);
        _jumper = new AgentJumper(_agent, this, _animCurve, _jumpSpeed);
        _rotator = new QuaternionRotator(_rotationSpeed, transform);
        _health = new CommonHealth(_maxHealth);
        _death = new DeathFromHealth(_health);
        _wallet = new Wallet(_coinsToWin);
    }

    private void Update()
    {
        _death.UpdateDeathState();
        _rotator.Update(Time.deltaTime);
    }

    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData)
    {
        if (_agent.isOnOffMeshLink)
        {
            offMeshLinkData = _agent.currentOffMeshLinkData;
            return true;
        }

        offMeshLinkData = default(OffMeshLinkData);
        return false;
    }

    public void MoveToPoint(Vector3 position) => _agent.SetDestination(position);

    public void SetInputDirectionRotator(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void TakeDamage(int damage) => _health.TakeDamage(damage);

    public void Collect() => _wallet.AddCoin();

    public void Jump(OffMeshLinkData offMeshLinkData) => _jumper.Jump(offMeshLinkData);
}
