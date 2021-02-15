using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickable : MonoBehaviour
{
    

    private Grab rob;


    // Start is called before the first frame update
    void Start()
    {
       
        rob = GameObject.FindGameObjectWithTag("Player").GetComponent<Grab>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        MissionFinisher Destination = other.GetComponent<MissionFinisher>();
        

        if(Destination != null)
        {
            Destination.MissionComplete();
            Destroy(transform.gameObject,0.5f);
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(rob.transform.position, transform.position) < 0.9f)    
                rob.objectfound = true;
            else   
                rob.objectfound = false;
    }

    public void SetCanDrop(bool x)
    {
        rob.canDrop = x;
    }
}
