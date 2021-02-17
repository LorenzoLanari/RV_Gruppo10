using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Deriverable : MonoBehaviour
{

     void Start()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), 2f, RotateMode.LocalAxisAdd).SetLoops(-1, LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {

        TPC_Rob Rob = other.GetComponent<TPC_Rob>();
        
        if(Rob != null)
        {
            FindObjectOfType<AudioManager>().Play("Item");
            transform.gameObject.SetActive(false);
            Rob.collected = true;
        }
    }
}
