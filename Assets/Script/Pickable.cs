using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    
    public GameObject Destination;
    private Grab rob;


    // Start is called before the first frame update
    void Start()
    {
        Destination = GameObject.FindGameObjectWithTag("QuestDestination");
        rob = GameObject.Find("Rob").GetComponent<Grab>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(Destination.GetComponent<Collider>() == other)
        {
            Destination.GetComponent<MissionFinisher>().MissionComplete();
            Destroy(transform.gameObject,1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
       

            if (Vector3.Distance(rob.transform.position, Destination.transform.position) < 1.5f)
                   rob.canDrop = true;       
            else
                   rob.canDrop = false;
 
            if (Vector3.Distance(rob.transform.position, transform.position) < 0.9f)    
                rob.objectfound = true;
            else   
                rob.objectfound = false;
           




    }
}
