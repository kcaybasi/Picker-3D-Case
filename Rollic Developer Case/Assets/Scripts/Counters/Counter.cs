using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _counterText;
    [SerializeField] CounterData _counterData;
    [SerializeField] ParticleSystem _hitParticle;

    public CounterData CounterData { get => _counterData; }

    private void Start()
    {
        CounterData.HittedObjectCount = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            _counterText.text = CounterData.HittedObjectCount + "/" + CounterData.RequiredCollectible;
            CounterData.HittedObjectCount++;
            if (!_hitParticle.isPlaying)
            {
                _hitParticle.Play();
            }

            Destroy(collision.gameObject, .5f);
        }
    }
}
