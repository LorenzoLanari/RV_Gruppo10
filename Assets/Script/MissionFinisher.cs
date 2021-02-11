using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFinisher : MonoBehaviour
{
    public Mission mission;
    public TPC_Rob Rob;
    public GameObject missionComplete;
    public MissionManager manager;

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
