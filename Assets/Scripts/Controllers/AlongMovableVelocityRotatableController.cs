public class AlongMovableVelocityRotatableController : Controller
{
    private IRotatable _rotatable;
    private IMovable _movable;

    public AlongMovableVelocityRotatableController(IRotatable rotatable, IMovable movable)
    {
        _rotatable = rotatable;
        _movable = movable;
    }

    protected override void UpdateLogic(float timeDeltaTime)
    {
        _rotatable.SetInputDirectionRotator(_movable.CurrentVelocity);
    }
}
