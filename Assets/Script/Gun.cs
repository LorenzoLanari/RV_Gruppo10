using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.5f, 1.5f)]
    private float FireRate = 1;

    [SerializeField]
    private Transform ShootingPoint;


    [SerializeField]
    private int Damage = 1;

    private float timer;    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= FireRate)
        {
            if(Input.GetButton("Fire1"))
            {
                timer = 0f;
                FireGun();
            }
        }
    }

    private void FireGun()
    {
        Debug.DrawRay(ShootingPoint.position, ShootingPoint.forward * 100, Color.red, 2f);

        Ray ray = new Ray(ShootingPoint.position, ShootingPoint.forward);
        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo, 100))
        {
            var health = hitinfo.collider.GetComponent<Health>();
            if (health != null)
                health.TakeDamage(Damage);
        }



    }
}
