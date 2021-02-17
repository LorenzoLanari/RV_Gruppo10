using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ventola : MonoBehaviour
{ 
    // Update is called once per frame
    void Start()
    {
        transform.DORotate(new Vector3(0f, 0f, 360f), 0.005f, RotateMode.WorldAxisAdd).SetLoops(-1, LoopType.Restart);
    }
}
