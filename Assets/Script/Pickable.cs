using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    public Transform Destination;
    private Collider mycollider;
    private Grab rob;

    // Start is called before the first frame update
    void Start()
    {
        mycollider = GetComponent<Collider>();
        rob = GameObject.Find("Rob").GetComponent<Grab>();
    }

    // Update is called once per frame
    void Update()
    {
       Collider[] hitColliders = Physics.OverlapSphere(Destination.position, 3f);
        foreach(var hitCollider in hitColliders)
        {
            if (hitCollider == mycollider)
                rob.canDrop = true;

        }


        if (Vector3.Distance(rob.transform.position, transform.position) < 1.5f)
        {
          
            rob.objectfound = true;     
        }
        else
            rob.objectfound = false;

    }
}
