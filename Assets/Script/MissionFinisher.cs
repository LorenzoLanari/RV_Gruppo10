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
   

    private MissionWaypoint waypoint;

    private void Start()
    {
        waypoint = gameObject.GetComponent<MissionWaypoint>();

        if (waypoint != null)
        {
            ActivateWaypoint(true);
            SetWaypoint(waypoint.target);
        }
       
        
        
    }
    public void MissionComplete()
    {
        mission.isActive = false;  
        missionComplete.SetActive(true);
        Invoke("Cleaner", 2f);
        if(mission.goal.goalType == GoalType.Deliver)
            Rob.GetComponent<Grab>().enabled = false;

        if (waypoint != null)
            ActivateWaypoint(false);

        manager.NextMission();
        gameObject.SetActive(false);

    }
    
    public void Cleaner()
    {
        missionComplete.SetActive(false);
    } 

    public void SetWaypoint(Transform target)
    {
        waypoint.target = target;
    }

    public void ActivateWaypoint(bool state)
    {
        waypoint.img.gameObject.SetActive(state);
    }
}
