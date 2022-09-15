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
        
       
        if (_ctx.Counter.CounterData.CounterType == CounterData.CounterTypes.Regular)
        {

            _ctx.StartCoroutine(CounterRoutine());
          

        }
        else
        {
            UIManager.Instance.OpenMenu(2);
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



    IEnumerator CounterRoutine()
    {
        _ctx.Counter.transform.DOMoveY(-4f, 2.5f);
        MeshRenderer meshRenderer = _ctx.Counter.GetComponent<MeshRenderer>();
        meshRenderer.material.DOColor(_ctx.CounterTargetColor, 1.5f);
        yield return new WaitForSeconds(.75f);
        SwitchState(_factory.Movement());
    }
}
