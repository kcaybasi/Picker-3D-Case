using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] CollectibleData _collectibleData;

    public CollectibleData CollectibleData { get => _collectibleData; }

    private void OnCollisionEnter(Collision collision)
    {

    }

}
