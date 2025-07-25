using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class AgentJumper
{
    private NavMeshAgent _agent;

    private MonoBehaviour _coroutineRunner;

    private Coroutine _process;

    private AnimationCurve _jumpCurve;

    private float _jumpSpeed;

    public AgentJumper(NavMeshAgent agent, MonoBehaviour coroutineRunner, AnimationCurve curve, float jumpSpeed)
    {
        _agent = agent;
        _coroutineRunner = coroutineRunner;
        _jumpCurve = curve;
        _jumpSpeed = jumpSpeed;
    }

    public bool InProcess => _process != null;

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if (InProcess)
            return;

        _process = _coroutineRunner.StartCoroutine(ProcessJump(offMeshLinkData));
    }

    private IEnumerator ProcessJump(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPosition = offMeshLinkData.startPos;
        Vector3 endPosition = offMeshLinkData.endPos;

        float timeToJump = Vector3.Distance(startPosition, endPosition) / _jumpSpeed;

        float progress = 0;

        while (progress < timeToJump)
        {
            float yOffset = _jumpCurve.Evaluate(progress / timeToJump);

            _agent.transform.position = Vector3.Lerp(offMeshLinkData.startPos, offMeshLinkData.endPos, progress / timeToJump) + Vector3.up * yOffset;
            progress += Time.deltaTime;
            yield return null; 
        }

        _agent.CompleteOffMeshLink();

        _process = null;
    }
}
