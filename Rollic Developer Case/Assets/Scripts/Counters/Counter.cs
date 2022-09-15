using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] CounterData _counterData;
    [SerializeField] TextMeshProUGUI _counterText;  
    [SerializeField] ParticleSystem _hitParticle;
    [SerializeField] Transform _collectibleTargetTransform;

    int _hittedObjectCount;
    public CounterData CounterData { get => _counterData; }
    public int HittedObjectCount { get => _hittedObjectCount; }
    public Transform CollectibleTargetTransform { get => _collectibleTargetTransform; }

    private void Start()
    {
        // To update counter text at beginning

        _counterText.text = _hittedObjectCount + "/" + CounterData.RequiredCollectible;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            _counterText.text = _hittedObjectCount + "/" + CounterData.RequiredCollectible;
            _hittedObjectCount++;
            if (!_hitParticle.isPlaying)
            {
                _hitParticle.Play();
            }

            Destroy(collision.gameObject, 1f);

        }
 
    }

}
