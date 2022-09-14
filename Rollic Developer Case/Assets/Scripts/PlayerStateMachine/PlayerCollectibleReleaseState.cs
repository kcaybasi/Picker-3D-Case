using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollectibleReleaseState : PlayerBaseState
{
    int _collectedCount;
    int _requiredCollectible;
    float _delayIncrement;
  

    public PlayerCollectibleReleaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }
    public override void EnterState()
    {
        _requiredCollectible = _ctx.Counter.CounterData.RequiredCollectible;
        _collectedCount = _ctx.Counter.CounterData.HittedObjectCount;
        _ctx.Rigidbody.isKinematic = true;
        for (int i = 0; i < _ctx.Collector.CollectedObjectList.Count; i++)
        {
            //_ctx.Collector.CollectedObjectList[i].GetComponent<Rigidbody>().AddForce((Vector3.forward * 100f+ Vector3.up * 35f) * Time.fixedDeltaTime, ForceMode.Impulse);
            _ctx.Collector.CollectedObjectList[i].transform.DOMove(_ctx.Counter.transform.parent.position, .15f+_delayIncrement);
            _delayIncrement += 0.05f;
           
        }
    }


    public override void CheckSwitchStates()
    {
        if (_ctx.Collector.CollectedObjectList.Count == 0)
        {
            if (_collectedCount >= _requiredCollectible)
            {
                SwitchState(_factory.GameSuccess());
            }
            else
            {
                SwitchState(_factory.GameFail());
            }
        }
        else
        {
            return;
        }
    }



    public override void ExitState()
    {
        _delayIncrement = 0f;
    }

    public override void FixedUpdateState()
    {

    }

    public override void OnTriggerEnter(Collider collider)
    {
       
    }

    public override void UpdateState()
    {
        CheckSwitchStates();
    }
}
