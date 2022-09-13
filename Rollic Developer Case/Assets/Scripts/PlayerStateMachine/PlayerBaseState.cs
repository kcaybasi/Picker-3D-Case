using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState 
{

    protected PlayerStateManager _ctx;
    protected PlayerStateFactory _factory;

    public PlayerBaseState(PlayerStateManager currentContext,PlayerStateFactory playerStateFactory)
    {
        _ctx = currentContext;
        _factory = playerStateFactory;
    }

    public abstract void EnterState();
    public abstract void UpdateState();

    public abstract void FixedUpdateState();
    public abstract void ExitState();
    public abstract void CheckSwitchStates();

    public abstract void OnTriggerEnter(Collider collider);
        

    protected void SwitchState(PlayerBaseState newState)
    {

        ExitState();

        newState.EnterState();

        _ctx.CurrentState = newState;
    }
}
