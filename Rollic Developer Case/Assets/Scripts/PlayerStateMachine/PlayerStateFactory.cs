

public class PlayerStateFactory
{

    PlayerStateManager _context;

    public PlayerStateFactory (PlayerStateManager currentContext)
    {
        _context = currentContext;
    }



    public PlayerBaseState Idle()
    {
        return new PlayerIdleState(_context, this);
    }

    public PlayerBaseState Movement()
    {
        return new PlayerMovementState(_context, this);
    }

    public PlayerBaseState GameSuccess()
    {
        return new PlayerGameSuccessState(_context, this);
    }

    public PlayerBaseState GameFail()
    {
        return new PlayerGameFailState(_context, this);
    }

    public PlayerBaseState Release()
    {
        return new PlayerCollectibleReleaseState(_context, this);
    }

}
