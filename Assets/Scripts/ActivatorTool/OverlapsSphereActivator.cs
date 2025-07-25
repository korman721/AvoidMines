using System.Collections;
using UnityEngine;

public class OverlapsSphereActivator : ActivatorTool
{
    private float _activateRadius;

    private float _timeToDetonate;

    private Coroutine _process;

    private MonoBehaviour _coroutineRunner;

    public OverlapsSphereActivator(IActivateble activateble, float timeToDetonate, float activateRadius, MonoBehaviour coroutineRunner) : base(activateble)
    {
        _activateRadius = activateRadius;
        _timeToDetonate = timeToDetonate;
        _coroutineRunner = coroutineRunner;
    }

    public override void ActivateCondition()
    {
        Collider[] colliders = Physics.OverlapSphere(_activateble.Transform.position, _activateRadius);

        foreach (Collider collider in colliders)
            if (collider.GetComponent<IMovable>() != null)
            {
                _isActivated = true;
                Debug.Log("Mine Activated");
            }

        if (_isActivated)
        {
            if (_process == null)
                _process = _coroutineRunner.StartCoroutine(ActivateProcess());
        }
    }

    private IEnumerator ActivateProcess()
    {
        yield return new WaitForSeconds(_timeToDetonate);

        _activateble.Activate();

        _process = null;
    }
}