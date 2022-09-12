using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

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
            
            collision.gameObject.tag = "Fired";
            collision.transform.DOKill();
            gameManager.CollectedCount++;
            gameManager.CheckLevelSuccess();
        }
    }


}
