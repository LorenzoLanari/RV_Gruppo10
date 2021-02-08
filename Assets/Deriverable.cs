using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deriverable : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {

        TPC_Rob Rob = other.GetComponent<TPC_Rob>();
        
        if(Rob != null)
        {
            transform.gameObject.SetActive(false);
            Rob.collected = true;
        }
    }
}
