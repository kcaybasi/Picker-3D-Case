﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementState : PlayerBaseState
{
    public PlayerMovementState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        UIManager.Instance.CloseMenu(0);
    }

    public override void ExitState()
    {
        
    }

    public override void FixedUpdateState()
    {
        _ctx.Move();
    }

    public override void OnTriggerEnter(Collider collider)
    {
       
    }

    public override void UpdateState()
    {
        
    }
}