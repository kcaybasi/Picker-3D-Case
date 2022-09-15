using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class Counter : MonoBehaviour
{
    [SerializeField] CounterData _counterData;
    [SerializeField] TextMeshProUGUI _counterText;  
    [SerializeField] ParticleSystem _hitParticle;
    [SerializeField] ParticleSystem _successParticle;
    [SerializeField] Transform _collectibleTargetTransform;

    int _hittedObjectCount;
    public CounterData CounterData { get => _counterData; }
    public int HittedObjectCount { get => _hittedObjectCount; }
    public Transform CollectibleTargetTransform { get => _collectibleTargetTransform; }
    public ParticleSystem SuccessParticle { get => _successParticle; }

    private void Start()
    {
        // To update counter text at beginning

        _counterText.text = _hittedObjectCount + "/" + CounterData.RequiredCollectible;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            _hittedObjectCount++;
            _counterText.text = _hittedObjectCount + "/" + CounterData.RequiredCollectible;
            
            if (!_hitParticle.isPlaying)
            {
                _hitParticle.Play();
            }

            DOTween.Kill(collision.gameObject.transform);
            Destroy(collision.gameObject);

        }

    }



}
