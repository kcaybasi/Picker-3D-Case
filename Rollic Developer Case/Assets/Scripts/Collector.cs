using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    C_GameManager gameManager;

    private void Start()
    {
        gameManager = C_GameManager.Instance;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            gameManager.CollectedList.Add(other.gameObject);
            other.tag = "Collected";

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
        if (other.CompareTag("Finish"))
        {
            ShootCollectibles();
        }
    }

    void ShootCollectibles()
    {
        if (gameManager.CollectedList.Count > 0)
        {
            gameManager.CollectedList[0].GetComponent<Rigidbody>().AddForce((Vector3.forward * 300f + Vector3.up * 50f) * Time.fixedDeltaTime, ForceMode.Impulse);
            gameManager.CollectedList.RemoveAt(0);
        }

    }
}
