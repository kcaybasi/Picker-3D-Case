using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectibleReleaseState : PlayerBaseState
{
    int _collectedCount;
    int _requiredCollectible;
  

    public PlayerCollectibleReleaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }
    public override void EnterState()
    {
        _requiredCollectible = _ctx.Counter.counterData.RequiredCollectible;
        _collectedCount = _ctx.Collector.CollectedObjectList.Count;
        _ctx.Rigidbody.isKinematic = true;
        for (int i = 0; i < _ctx.Collector.CollectedObjectList.Count; i++)
        {
            _ctx.Collector.CollectedObjectList[i].GetComponent<Rigidbody>().AddForce((Vector3.forward * 100f+ Vector3.up * 35f) * Time.fixedDeltaTime, ForceMode.Impulse);
            
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
