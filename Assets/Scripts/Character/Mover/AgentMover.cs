using UnityEngine;
using UnityEngine.AI;

public class AgentMover
{
    private const float NormalAcceleration = 999f;

    private NavMeshAgent _agent;

    public Vector3 CurrentVelocity => _agent.desiredVelocity;

    public AgentMover(NavMeshAgent agent, float moveSpeed)
    {
        _agent = agent;
        _agent.speed = moveSpeed;
        _agent.acceleration = NormalAcceleration;
    }

    public void SetDestination(Vector3 position) => _agent.SetDestination(position);

    public void Stop() => _agent.isStopped = true;

    public void Resume() => _agent.isStopped = false;
}
