using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Finisher : MonoBehaviour
{

   

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Collectible"))
        {
            
            collision.gameObject.tag = "Fired";
            collision.transform.DOKill();
    
        }
    }


}
