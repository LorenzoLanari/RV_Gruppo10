using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Playables;
using DG.Tweening;

public class TimelineController : MonoBehaviour
{
    public PlayableDirector playable;
    public GameObject CameraFree;
    public TPC_Rob Rob;
    
   public void Play()
    {
        CameraFree.SetActive(false);
        Rob.GetComponent<Grab>().enabled = false;
        Rob.GetComponent<Aiming>().enabled = false;
        Rob.endMission();
        Invoke("delayedPlay", 7f);      
        playable.Play();

    }
    public void delayedPlay() { 
        Rob.enabled = false;
    }
}
