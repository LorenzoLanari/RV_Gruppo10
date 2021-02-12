using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MissionFinisher : MonoBehaviour
{
    public Mission mission;
    public TPC_Rob Rob;
    public GameObject missionComplete;
    public MissionManager manager;
    public GameObject Arrow;

    private float StartPositionY;

    private void Start()
    {
        StartPositionY = Arrow.transform.position.y;
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(Arrow.transform.DOMoveY(StartPositionY + 1.5f, 2f));
        moveSequence.Append(Arrow.transform.DOMoveY(StartPositionY, 2f));
        moveSequence.SetLoops(-1);
        moveSequence.Play();
    }
    public void MissionComplete()
    {
        mission.isActive = false;  
        missionComplete.SetActive(true);
        Invoke("Cleaner", 2f);
        if(mission.goal.goalType == GoalType.Deliver)
            Rob.GetComponent<Grab>().enabled = false;
        
        manager.NextMission();
        gameObject.SetActive(false);

    }
    
    public void Cleaner()
    {
        missionComplete.SetActive(false);
    } 
}
