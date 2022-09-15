using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collector : MonoBehaviour
{
    [SerializeField] List<GameObject> _collectedObjectList = new List<GameObject>();
    

    public List<GameObject> CollectedObjectList { get => _collectedObjectList; set => _collectedObjectList = value; }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            CollectedObjectList.Add(other.gameObject);
            other.tag = "Collected";
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collected"))
        {
            CollectedObjectList.Remove(other.gameObject);
            other.tag = "Collectible";
        }
    }

  
 
}
