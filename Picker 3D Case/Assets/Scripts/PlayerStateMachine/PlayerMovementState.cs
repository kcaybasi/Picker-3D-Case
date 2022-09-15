using System.Collections;
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
        _ctx.Rigidbody.isKinematic = false;
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
        if (collider.CompareTag("CounterTrigger"))
        {
            collider.enabled = false;
            _ctx.Counter = collider.transform.parent.GetComponent<Counter>();
            SwitchState(_factory.Release());
        }
    }

    public override void UpdateState()
    {
        
    }
}
