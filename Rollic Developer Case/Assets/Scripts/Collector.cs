using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{

    [SerializeField] Transform _finishTarget;
    bool _isShootingAllowed;
    UIManager gameManager;

    private void Start()
    {
        
    }


    private void Update()
    {
        if (_isShootingAllowed)
        {
           // ShootCollectibles();
        }
        else
        {
            return;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
           
            other.tag = "Collected";

        }

        if (other.CompareTag("Finish"))
        {
            _isShootingAllowed = true;
           
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
          
            other.tag = "Collectible";
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

}
