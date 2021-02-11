using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolvenza : MonoBehaviour
{
    public Animator  DissolvenzaAnimator;

    public void Play()
    {
        DissolvenzaAnimator.SetTrigger("start");
    }
}
