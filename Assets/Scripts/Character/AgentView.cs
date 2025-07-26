using System.Collections;
using UnityEditor;
using UnityEngine;

public class AgentView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int TakeDamageKey = Animator.StringToHash("TakeDamage");
    private readonly int DieKey = Animator.StringToHash("Die");
    private readonly int JumpKey = Animator.StringToHash("IsJumping");

    private const string InjureLayerKey = "InjureLayer";
    private const string EdgeDissolveKey = "_Edge";

    private const float InjureFactor = 0.3f;

    private const int TimeToChangeMaterial = 1;

    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _damageMaterial;
    [SerializeField] private Material _dissolveMaterial;
    [SerializeField] private Material _eyesMaterial;

    [SerializeField] private AgentCharacter _agent;
    [SerializeField] private Animator _animator;

    [SerializeField] private float _timeToDissolve;

    private SkinnedMeshRenderer[] _skinnedMeshRenderers;

    private Coroutine _damageProcess;

    private int _currentHealth;
    private int _previousHealth;

    private float _healthForInjure;
    private float _currentTimeBeforeDissolve;

    private void Awake()
    {
        _currentHealth = _agent.Health;
        _previousHealth = _agent.Health;

        _healthForInjure = _currentHealth * InjureFactor;

        _skinnedMeshRenderers = GetComponentsInChildren<SkinnedMeshRenderer>();
    }

    private void Update()
    {
        _currentHealth = _agent.Health;

        if (_currentHealth < _healthForInjure)
            SetInjureLayer();

        Jumping();

        if (_agent.CurrentVelocity.magnitude > 0.05f)
            StartRunning(); 
        else
            StopRunning();

        TakeHit();
    }

    private void StartRunning() => _animator.SetBool(IsRunningKey, true);

    private void StopRunning() => _animator.SetBool(IsRunningKey, false);

    private void TakeHit()
    {
        if (_currentHealth != _previousHealth)
            if (_damageProcess == null)
                _damageProcess = StartCoroutine(TakeHitProcess());
            else
            {
                StopCoroutine(_damageProcess);
                _damageProcess = StartCoroutine(TakeHitProcess());
            }
    }

    private void Jumping() => _animator.SetBool(JumpKey, _agent.InProcessJump);

    private void Die() => _animator.SetTrigger(DieKey);

    private void SetInjureLayer() => _animator.SetLayerWeight(_animator.GetLayerIndex(InjureLayerKey), 1);

    private IEnumerator TakeHitProcess()
    {
        _animator.SetTrigger(TakeDamageKey);
        _previousHealth = _currentHealth;

        SetAnyMaterial(_damageMaterial);

        yield return new WaitForSeconds(TimeToChangeMaterial);

        SetAnyMaterial(_defaultMaterial);

        if (_currentHealth <= 0)
            Die();

        _damageProcess = null;
    }

    private void SetAnyMaterial(Material material)
    {
        foreach (SkinnedMeshRenderer skinnedMeshRenderer in _skinnedMeshRenderers)
            if (skinnedMeshRenderer.material != _eyesMaterial)
                skinnedMeshRenderer.material = material;
    }

    private void SetFloatToMaterial(string key)
    {
        float progress = 0.3f + _currentTimeBeforeDissolve / _timeToDissolve;

        if (progress >= 1f)
            return;

        foreach (SkinnedMeshRenderer skinnedMeshRenderer in _skinnedMeshRenderers)
            skinnedMeshRenderer.material.SetFloat(key, progress);
    }

    
}
