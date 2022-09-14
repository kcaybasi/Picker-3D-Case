using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
        Debug.Log("heye");
       
        if (_ctx.Counter.CounterData.CounterType == CounterData.CounterTypes.Regular)
        {
            _ctx.Counter.transform.DOMoveY(-4f, .5f);

        }
        else
        {

        }
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
