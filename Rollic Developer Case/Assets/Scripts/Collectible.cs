using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * Time.fixedDeltaTime * 300f,ForceMode.Impulse);
        }
    }
}
