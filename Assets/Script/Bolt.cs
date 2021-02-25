using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bolt : MonoBehaviour
{
    private Rob_Health Rob;
    private Health Acaro;
    
    void Awake()
    {
        Invoke("PlaySound", 1.5f);
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        Rob = other.GetComponent<Rob_Health>();
        Acaro = other.GetComponent<Health>();
      

        if (Rob != null)
        {
            FindObjectOfType<AudioManager>().Play("Damage");
            Rob.TakeDamage(1);
        }
         
        if( Acaro != null)
        {
           
            Acaro.TakeDamage(5);
        }
       
    }

    public void PlaySound()
    {
        FindObjectOfType<AudioManager>().Play("Bolt");
    }

    private void OnDisable()
    {
        FindObjectOfType<AudioManager>().Stop("Bolt");
    }
}
