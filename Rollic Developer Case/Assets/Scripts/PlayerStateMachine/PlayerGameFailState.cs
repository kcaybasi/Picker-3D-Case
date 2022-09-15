using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameFailState : PlayerBaseState
{
    public PlayerGameFailState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    public override void CheckSwitchStates()
    {
        
    }

    public override void EnterState()
    {
        UIManager.Instance.OpenMenu(1);
    }

    public override void ExitState()
    {
   
    }

    public override void FixedUpdateState()
    {
       
    }

    public override void OnTriggerEnter(Collider collider)
    {
       
    }

    public override void UpdateState()
    {
        
    }
}
