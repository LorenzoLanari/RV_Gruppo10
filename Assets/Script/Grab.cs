using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grab : MonoBehaviour
{
    public GameObject LetterE;
    private GameObject _instance = null;
    private Vector3 Offset = new Vector3(0, 3.5f, 0);

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
    private Rigidbody _rigidbody;
    private Collider _collider;

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
            if (canGrab)
            {
                if (LetterE != null)
                {
                    LetterE.SetActive(true);
                }

            }
        }
        else if(!objectfound && !canDrop)
        {
            if (LetterE.activeSelf)
                LetterE.SetActive(false);
        }
        else if(canDrop && grabbing)
        {
            if (LetterE != null )
            {
                LetterE.SetActive(true);
            }
        }
        

    
        if (Input.GetKeyDown(KeyCode.E) && mutex)
        {
            if (canDrop && grabbing)
            {
                _rigidbody.isKinematic = false;
                Invoke("pickup", 0.4f);
                 mutex = false;
                 grabbing = false;
                 canDrop = false; 
                _tpc.mission.goal.ItemCollected();
                 Invoke("Carry", 1f);
                LetterE.SetActive(false);
            }
            else if(canGrab && !grabbing)
            {
                _rigidbody.isKinematic = true;
                Invoke("transport", 3f);
                Invoke("pickup", 6f);
                mutex = false;
                grabbing = true;
               
                Invoke("Carry", 6f);
                LetterE.SetActive(false);
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
                Physics.IgnoreCollision(_collider, _tpc.GetComponent<Collider>(),true);
                boxer.transform.localPosition = Vector3.zero;
                boxer.transform.localRotation = Quaternion.Euler(Vector3.zero);
            
        }

        else {
            GrabPoint.DetachChildren();
            Physics.IgnoreCollision(_collider, _tpc.GetComponent<Collider>(), false);
            boxer = null;
            _rigidbody = null;
        }
    }

    public bool CheckPosition()
    {

        //RaycastHit raycastHit = new RaycastHit();
        DebugExtension.DebugWireSphere(DetectPoint.position, 0.2f, 2f, true);
        Collider[] hitColliders = Physics.OverlapSphere(DetectPoint.position,0.2f,_tpc.groundCheckMask);
        foreach (var hitCollider in hitColliders)
        {

            if (hitCollider.GetComponent<Pickable>())
            {
                _collider = hitCollider;
                boxer = hitCollider.GetComponent<Pickable>();
                _rigidbody = boxer.GetComponent<Rigidbody>();
                return true;
            }
            else
                boxer = null;

        }
        
        //Quaternion.AngleAxis(12.0f, transform.forward) * transform.right
        return false;
    }


    
}
