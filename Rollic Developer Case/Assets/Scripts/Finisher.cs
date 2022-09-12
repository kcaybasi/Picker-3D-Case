using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finisher : MonoBehaviour
{

    C_GameManager gameManager;

    private void Start()
    {
        gameManager = C_GameManager.Instance;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            gameManager.CollectedCount++;
            collision.gameObject.tag = "Fired";
            gameManager.CheckLevelSuccess();
        }
    }


}
