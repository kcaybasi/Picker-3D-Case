using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New CollectibleData", menuName = "Collectible Data", order = 51)]
public class CollectibleData : ScriptableObject
{
    [SerializeField]
    private string _collectibleName;

    [SerializeField]
    private ParticleSystem _hitParticle;


    [SerializeField]
    public enum CollectibleStatus { Waiting, Collected,Fired}

    [SerializeField]

    private CollectibleStatus _collectibleStatus;

    public CollectibleStatus Status { get => _collectibleStatus; set => _collectibleStatus = value; }
    public ParticleSystem HitParticle { get => _hitParticle; set => _hitParticle = value; }
}
