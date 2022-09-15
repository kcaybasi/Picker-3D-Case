using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{

    Touch touch;
    public PlayerIdleState(PlayerStateManager currentCon, PlayerStateFactory playerStateFactory) : base(currentCon, playerStateFactory)
    {
    }


    public override void EnterState()
    {
    

    }

    public override void UpdateState()
    {
        CheckSwitchStates();

    }

    public override void CheckSwitchStates()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                SwitchState(_factory.Movement());
            }
            else
            {
                return;
            }
        }

    }

    public override void ExitState()
    {
    
    }

    public override void OnTriggerEnter(Collider collider)
    {
        
    }

    public override void FixedUpdateState()
    {
       
    }
}
