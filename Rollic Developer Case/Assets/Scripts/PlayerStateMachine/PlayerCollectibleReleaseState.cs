﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCollectibleReleaseState : PlayerBaseState
{
    int _collectedCount;
    int _requiredCollectible;
    float _delayIncrement;

    GameObject _lastCollectible;
  

    public PlayerCollectibleReleaseState(PlayerStateManager currentContext, PlayerStateFactory playerStateFactory) : base(currentContext, playerStateFactory)
    {
    }
    public override void EnterState()
    {
        _requiredCollectible = _ctx.Counter.CounterData.RequiredCollectible;
        _collectedCount = _ctx.Collector.CollectedObjectList.Count;
        _ctx.Rigidbody.isKinematic = true;

        int _lastIndex = _ctx.Collector.CollectedObjectList.Count-1 ;
        _lastCollectible = _ctx.Collector.CollectedObjectList[_lastIndex];

        for (int i = 0; i < _ctx.Collector.CollectedObjectList.Count; i++)
        {
            var _collectibleObj = _ctx.Collector.CollectedObjectList[i].transform;
            
            
            _collectibleObj.DOMove(_ctx.Counter.CollectibleTargetTransform.position, .15f+_delayIncrement);            
            _delayIncrement += 0.025f;
           
        }
    }

    public override void CheckSwitchStates()
    {
        if (_ctx.Collector.CollectedObjectList.Count == 0)
        {
            if (_collectedCount >= _requiredCollectible)
            {
                float _lastCollectibleDistance = Vector3.Distance(_lastCollectible.transform.position, _ctx.Counter.CollectibleTargetTransform.position);

                if ((_lastCollectibleDistance) <= 2f)
                {
                    SwitchState(_factory.GameSuccess());
                }
                

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
