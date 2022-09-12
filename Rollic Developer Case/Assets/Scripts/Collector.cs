using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{

    [SerializeField] Transform _finishTarget;
    bool _isShootingAllowed;
    C_GameManager gameManager;

    private void Start()
    {
        gameManager = C_GameManager.Instance;
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
            gameManager.CollectedList.Add(other.gameObject);
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
            gameManager.CollectedList.Remove(other.gameObject);
            other.tag = "Collectible";
        }
    }

    private void OnTriggerStay(Collider other)
    {

    }

    void ShootCollectibles()
    {
        if (gameManager.CollectedList.Count > 0)
        {
            StartCoroutine(ShootingRoutine());
        }

    }

    IEnumerator ShootingRoutine()
    {
        gameManager.CollectedList[0].GetComponent<Rigidbody>().isKinematic = true;
        Tween moveTween = gameManager.CollectedList[0].transform.DOMove(_finishTarget.position, .5f, false);
        yield return  moveTween.WaitForCompletion();
        gameManager.CollectedList.Remove(gameManager.CollectedList[0]);
    }
}
