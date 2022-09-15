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
        _ctx.StartCoroutine(FailRoutine());
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

    IEnumerator FailRoutine()
    {
        yield return new WaitForSeconds(1f);
        UIManager.Instance.OpenMenu(1);
    }
}
