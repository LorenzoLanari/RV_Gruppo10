using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform Destination;

    private void OnTriggerEnter(Collider other)
    {
        TPC_Rob Rob = other.GetComponent<TPC_Rob>();
        if(Rob != null && Rob.mission.isActive)
        {
            Rob.transform.position = Destination.position;
        }
    }
}
