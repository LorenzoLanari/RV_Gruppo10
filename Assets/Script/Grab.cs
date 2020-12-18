using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool grabbing = false;
    public bool mutex = true;
    public bool objectfound = false;
    private bool patchv2 = false;
    public Transform GrabPoint;
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
        if (objectfound)
        {     
            patchv2 = CheckPosition();
        }

        if (patchv2)
        {


            if (Input.GetKeyDown(KeyCode.E) && mutex)
            {
             
                    if (grabbing)
                    {

                        boxer.transform.SetParent(null);
                        mutex = false;
                        grabbing = false;
                        Invoke("Carry", 5.2f);
                    }
                    else
                    {
                        boxer.transform.SetParent(GrabPoint);
                        Physics.IgnoreCollision(boxer.GetComponent<Collider>(), GetComponent<Collider>());
                        mutex = false;
                        grabbing = true;
                        Invoke("Carry", 5.2f);
                            
                    }            
            }

        }

    }
    public void Carry() {
        mutex = true;
    }

    public bool CheckPosition()
    {
        Ray raygrab = new Ray(transform.position, transform.forward);
        RaycastHit raycastHit = new RaycastHit();
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (Physics.Raycast(raygrab, out raycastHit, 500))
        {
            if (raycastHit.collider.GetComponent<Pickable>())
            {
                boxer = raycastHit.collider.GetComponent<Pickable>();
                
                return true;
            }
            else
                boxer = null;
        }
        //Quaternion.AngleAxis(12.0f, transform.forward) * transform.right
        return false;
    }
}
