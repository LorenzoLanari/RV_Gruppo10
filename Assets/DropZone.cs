using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public GameObject Box;
    private void Start()
    {
        Box = GameObject.FindGameObjectWithTag("Pickable");
    }

    private void OnTriggerEnter(Collider other)
    {    
        if (other == Box.GetComponent<Collider>())
        {
           
            Box.GetComponent<Pickable>().SetCanDrop(true);
        }
       

    }
}
