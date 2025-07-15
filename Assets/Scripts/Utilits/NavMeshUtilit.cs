using UnityEngine;
using UnityEngine.AI;

public class NavMeshUtilit
{
    public static bool TryGetPath(NavMeshAgent agent, Vector3 targetPosition, NavMeshPath path)
    {
        if (agent.CalculatePath(targetPosition, path))
            return true;

        return false;
    }
}
