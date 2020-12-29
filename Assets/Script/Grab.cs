﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool grabbing = false;
    public bool mutex = true;
    public bool objectfound = false;
    public bool canDrop = false;
    private bool canGrab = false;
    private bool flag = false;
    public Transform GrabPoint;
    public Transform DetectPoint;
    private TPC_Rob _tpc;
    private Pickable boxer;



    // Start is called before the first frame update
    void Start()
    {
        _tpc = GetComponent<TPC_Rob>();
    }

    // Update is called once per frame
    void Update()
    {
        if (objectfound && mutex)
        {     
            canGrab = CheckPosition();
        }

        

    
        if (Input.GetKeyDown(KeyCode.E) && mutex)
        {
            if (canDrop && grabbing)
            {
                    
                 Invoke("pickup", 3f);
                 mutex = false;
                 grabbing = false;
                 canDrop = false;
                 Invoke("Carry", 6f);                
            }
            else if(canGrab && !grabbing)
            {
                Invoke("transport", 3f);
                Invoke("pickup", 6f);
                mutex = false;
                grabbing = true;
                Invoke("Carry", 6f);

            }            
        }

        if(!mutex && grabbing && flag)
             boxer.transform.position = Vector3.MoveTowards(boxer.transform.position, GrabPoint.position,Time.deltaTime*0.3f);

        
            
    }
    public void Carry() {
        mutex = true;
        flag = false;
    }
    public void transport()
    {
        flag = true;

    }
    public void pickup() {
        if (grabbing)
        {    
                boxer.transform.SetParent(GrabPoint);
                boxer.transform.localPosition = Vector3.zero;
                boxer.transform.localRotation = Quaternion.Euler(Vector3.zero);
        }

        else {
            GrabPoint.DetachChildren();    
        }
    }

    public bool CheckPosition()
    {
        
        
        //RaycastHit raycastHit = new RaycastHit();
        DebugExtension.DebugWireSphere(DetectPoint.position, 0.1f, 2f, true);
        Collider[] hitColliders = Physics.OverlapSphere(DetectPoint.position,0.1f,_tpc.groundCheckMask);
        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.GetComponent<Pickable>())
            {
                boxer = hitCollider.GetComponent<Pickable>();
                
                return true;
            }
            else
                boxer = null;

        }
        
        //Quaternion.AngleAxis(12.0f, transform.forward) * transform.right
        return false;
    }
}
