public abstract class Controller 
{
    private bool _isEnable;

    public virtual void Enable() => _isEnable = true;

    public virtual void Disable() => _isEnable = false;

    public void Update(float timeDeltaTime)
    {
        if (_isEnable == false)
            return;

        UpdateLogic(timeDeltaTime);
    }

    protected abstract void UpdateLogic(float timeDeltaTime);
}
