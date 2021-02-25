using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerName : MonoBehaviour
{

    public string Name;
    public Text triggerName;
    public GameObject trigger;

    private void OnTriggerEnter(Collider other)
    {
        TPC_Rob Rob = other.GetComponent<TPC_Rob>();

        if (Rob != null)
        {
            trigger.SetActive(true);
            triggerName.text = Name;

        }
    }

    private void OnTriggerExit(Collider other)
    {
        TPC_Rob Rob = other.GetComponent<TPC_Rob>();

        if (Rob != null)
        {
            trigger.SetActive(false);
            triggerName.text = null;

        }
    }
}
