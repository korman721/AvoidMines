using UnityEngine.AI;

public class AgentJumpController : Controller
{
    private AgentCharacter _agent;

    public AgentJumpController(AgentCharacter agent)
    {
        _agent = agent;
    }

    protected override void UpdateLogic(float timeDeltaTime)
    {
        if (_agent.IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData))
        {
            if (_agent.InProcessJump == false)
            {
                _agent.SetInputDirectionRotator(offMeshLinkData.endPos - offMeshLinkData.startPos);

                _agent.Jump(offMeshLinkData);
            }

            return;
        }
    }
}
