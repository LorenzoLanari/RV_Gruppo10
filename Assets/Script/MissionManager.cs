using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public MissionGiver[] Givers;
    private int _active=0;

    private void Awake()
    {        
        Givers[_active].transform.gameObject.SetActive(true);
    }
    public void NextMission() {
        if (_active < Givers.Length - 1)
        {
            _active++;
            Givers[_active].transform.gameObject.SetActive(true);
        }
        else
            Debug.Log("Missioni finite");
    }
    public void AcceptMission() {
        if(Givers[_active].mission.goal.goalType == GoalType.Deliver || Givers[_active].mission.goal.goalType == GoalType.Handin)
            Givers[_active].AcceptMission();
        else
            Givers[_active].AcceptPuzzle();
    }
}
