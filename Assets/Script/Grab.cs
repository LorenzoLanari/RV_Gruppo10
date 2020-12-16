using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public bool grabbing = false;
    public bool mutex = true;

    private TPC_Rob _tpc;

    // Start is called before the first frame update
    void Start()
    {
        _tpc = GetComponent<TPC_Rob>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && mutex)
        {
            if (grabbing)
            {
                mutex = false;
                grabbing = false;
                Invoke("Carry", 5.2f);
            }
            else
            {
                mutex = false;
                grabbing = true;
                Invoke("Carry", 5.2f);
                            
            }
        }
    }
    public void Carry() {
        mutex = true;
    }
}
