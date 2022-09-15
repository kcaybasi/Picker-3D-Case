using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _counterText;
    [SerializeField] CounterData _counterData;
    [SerializeField] ParticleSystem _hitParticle;
    int _hittedObjectCount;
    public CounterData CounterData { get => _counterData; }
    public int HittedObjectCount { get => _hittedObjectCount; }

 

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
