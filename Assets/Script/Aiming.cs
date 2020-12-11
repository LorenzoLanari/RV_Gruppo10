using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{

    public GameObject _tpCamera;
    public GameObject _aimCamera;
    public GameObject aimReticle;
    public Transform _target;

    private TPC_Rob _tpc;
    private float rotationPower = 2f; //3f
    private Transform _startingRotation;
    private Quaternion nextRotation;
    private float rotationLerp = 0.5f;


    // Start is called before the first frame update
    void Start()
    {
        _tpc = GetComponent<TPC_Rob>();
        _startingRotation = _target.transform;
    }

    // Update is called once per frame
    void Update()
    {


        if (_tpc.shooting)
        {
            _tpCamera.SetActive(false);
            _aimCamera.SetActive(true);
            MoveTarget();
            StartCoroutine(ShowReticle());
        }
        else {
            _tpCamera.SetActive(true);
            _aimCamera.SetActive(false);
            aimReticle.SetActive(false);
            _target = _startingRotation;
        }
    }

    private void MoveTarget()
    {
        float h = Input.GetAxisRaw("Mouse X");
        float v = Input.GetAxisRaw("Mouse Y");
        _target.transform.rotation *= Quaternion.AngleAxis(h * rotationPower, Vector3.up);

        _target.transform.rotation *= Quaternion.AngleAxis(-v * rotationPower, Vector3.right);

        var angles = _target.transform.localEulerAngles;
        angles.z = 0;

        var angle = _target.transform.localEulerAngles.x;

        //Clamp the Up/Down rotation
        if (angle > 180 && angle < 340)
        {
            angles.x = 340;
        }
        else if (angle < 180 && angle > 40)
        {
            angles.x = 40;
        }


        _target.transform.localEulerAngles = angles;

        nextRotation = Quaternion.Lerp(_target.transform.rotation, nextRotation, Time.deltaTime * rotationLerp);
        
        transform.rotation = Quaternion.Euler(0,_target.transform.rotation.eulerAngles.y, 0);
        _target.transform.localEulerAngles = new Vector3(angles.x, 0, 0);
    }

    IEnumerator ShowReticle()
    {
        yield return new WaitForSeconds(0.25f);
        aimReticle.SetActive(enabled);
    }
}
