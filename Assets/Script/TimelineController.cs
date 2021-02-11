using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using DG.Tweening;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playable;
    public CinemachineFreeLook CameraFree;
    public TPC_Rob Rob;
  

   public void Play()
    {
       CameraFree.m_YAxis.m_InputAxisName = "";
       CameraFree.m_XAxis.m_InputAxisName = "";
       Rob.GetComponent<Grab>().enabled = false;
       Rob.GetComponent<Aiming>().enabled = false;
       Rob.enabled = false;
      
       playable.Play();

    }
}
