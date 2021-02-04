using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    
    public Transform Destination;
    private Grab rob;


    // Start is called before the first frame update
    void Start()
    {
        
        rob = GameObject.Find("Rob").GetComponent<Grab>();
    }

    // Update is called once per frame
    void Update()
    {
       

            if (Vector3.Distance(rob.transform.position, Destination.position) < 1.5f)
                   rob.canDrop = true;       
            else
                   rob.canDrop = false;
 
            if (Vector3.Distance(rob.transform.position, transform.position) < 0.9f)    
                rob.objectfound = true;
            else   
                rob.objectfound = false;
           

    }
}
