using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "New CounterleData", menuName = "Counter Data", order = 52)]
public class CounterData : ScriptableObject
{
   
    [SerializeField]
    private string _counterName;

    [SerializeField]

    int _requiredCollectible;

    [SerializeField]

    int _hittedObjectCount;

    [SerializeField]
    public enum CounterTypes { Regular, Finisher }

    [SerializeField]

    private CounterTypes _counterType;

    public CounterTypes CounterType { get => _counterType; set => _counterType = value; }
    public int RequiredCollectible { get => _requiredCollectible; set => _requiredCollectible = value; }
    public int HittedObjectCount { get => _hittedObjectCount; set => _hittedObjectCount = value; }
}
