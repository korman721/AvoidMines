using UnityEditor.Animations;
using UnityEngine;

public class AgentView : MonoBehaviour
{
    private readonly int IsRunningKey = Animator.StringToHash("IsRunning");
    private readonly int TakeDamageKey = Animator.StringToHash("TakeDamage");
    private readonly int DieKey = Animator.StringToHash("Die");

    private readonly string InjureLayerKey = "InjureLayer";

    private readonly float InjureFactor = 0.3f;

    [SerializeField] private AgentCharacter _character;
    [SerializeField] private Animator _animator;
    private AnimatorControllerLayer _layer;

    private int _currentHealth;
    private int _previousHealth;

    private float _healthForInjure;

    private void Awake()
    {
        _currentHealth = _character.Health;
        _previousHealth = _character.Health;

        _healthForInjure = _currentHealth * InjureFactor;
    }

    private void Update()
    {
        _currentHealth = _character.Health;

        if (_currentHealth < _healthForInjure)
            SetInjureLayer();

        if (_currentHealth <= 0)
            Die();

        if (_character.CurrentVelocity.magnitude > 0.05f)
            StartRunning(); 
        else
            StopRunning();

        if (_currentHealth != _previousHealth)
            TakeHit();
    }

    private void StartRunning() => _animator.SetBool(IsRunningKey, true);

    private void StopRunning() => _animator.SetBool(IsRunningKey, false);

    private void TakeHit()
    {
        _animator.SetTrigger(TakeDamageKey);
        _previousHealth = _currentHealth;
    }

    private void Die() => _animator.SetTrigger(DieKey);

    private void SetInjureLayer() => _animator.SetLayerWeight(_animator.GetLayerIndex(InjureLayerKey), 1);
}
