using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGameSuccessState : PlayerBaseState
{
    public PlayerGameSuccessState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }

    

    public override void CheckSwitchStates()
    {
 
    }

    public override void EnterState()
    {
        Debug.Log("Success");
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
