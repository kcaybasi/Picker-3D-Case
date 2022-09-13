using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New CollectibleData", menuName = "Collectible Data", order = 51)]
public class CollectibleData : ScriptableObject
{
    [SerializeField]
    private string _collectibleName;

    [SerializeField]
    public enum CollectibleStatus { Waiting, Collected,Fired}

    [SerializeField]

    private CollectibleStatus _collectibleStatus;

    public CollectibleStatus Status { get => _collectibleStatus; set => _collectibleStatus = value; }
}
