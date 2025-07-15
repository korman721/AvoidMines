public abstract class ActivatorTool
{
    protected IActivateble _activateble;

    protected bool _isActivated = false;

    public bool IsActivated => _isActivated;

    public ActivatorTool(IActivateble activateble)
    {
        _activateble = activateble;
    }

    public abstract void ActivateCondition();
}
