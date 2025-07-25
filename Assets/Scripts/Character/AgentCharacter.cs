using UnityEngine;
using UnityEngine.AI;

public class AgentCharacter : MonoBehaviour, IRotatable, IDamageble, IMovable, ICollectable
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _rotationSpeed;

    [SerializeField] private int _maxHealth;

    [SerializeField] private int _coinsToWin;

    private NavMeshAgent _agent;

    private AgentMover _mover;
    private Rotator _rotator;
    private Health _health;
    private Death _death;
    private Wallet _wallet;

    public Vector3 CurrentVelocity => _mover.CurrentVelocity;

    public Quaternion CurrentRotation => _rotator.GetCurrentRotation(transform);

    public bool IsDead => _death.IsDead;

    public int Health => _health.CurrentHealth;

    public Transform Transform => transform;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();

        _mover = new AgentMover(_agent, _moveSpeed);
        _rotator = new QuaternionRotator(transform, _rotationSpeed);
        _health = new CommonHealth(_maxHealth);
        _death = new DeathFromHealth(_health);
        _wallet = new Wallet(_coinsToWin);
    }

    private void Update()
    {
        _death.UpdateDeathState();
        _rotator.Update(Time.deltaTime);
    }

    public void MoveToPoint(Vector3 position) => _agent.SetDestination(position);

    public void SetInputDirectionRotator(Vector3 inputDirection) => _rotator.SetInputDirection(inputDirection);

    public void TakeDamage(int damage) => _health.TakeDamage(damage);

    public void Collect() => _wallet.AddCoin();
}
