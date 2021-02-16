using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Transform Destination;
    public Dissolvenza dissolvenza;
    private TPC_Rob Rob;
    private void OnTriggerEnter(Collider other)
    {
        Rob = other.GetComponent<TPC_Rob>();
        if(Rob != null && Rob.mission.isActive)
        {
            dissolvenza.gameObject.SetActive(true);
            Rob.GetComponent<Grab>().enabled = false;
            Rob.enabled = false;
            dissolvenza.Play();
            Rob.transform.position = Destination.position;
            Invoke("Enabler", 1f);
        }
    }
    public void Enabler()
    {
        Rob.GetComponent<Grab>().enabled = true;
        Rob.enabled = true;
    }
}
