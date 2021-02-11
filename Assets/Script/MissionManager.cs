using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public MissionGiver[] Givers;
    public List<GameObject> acari;

    private int _active=0;

    private void Awake()
    {        
        Givers[_active].transform.gameObject.SetActive(true);
    }
    public void NextMission() {
        if (_active < Givers.Length - 1)
        {
            if (Givers[_active].questGoal.activeSelf)
                Givers[_active].questGoal.SetActive(false);

            

            _active++;
            Givers[_active].transform.gameObject.SetActive(true);
        }
        else
        {
            if (Givers[_active].mission.goal.goalType == GoalType.Puzzle)
            {
                Time.timeScale = 1f;
                Givers[_active].puzzleWindow.SetActive(false);

                

            }
            if (Givers[_active].questGoal.activeSelf)
                    Givers[_active].questGoal.SetActive(false);

            foreach (GameObject acaro in acari)
            {
                if (acaro != null)
                {
                    Destroy(acaro);
                }
            }
            gameObject.GetComponent<TimelineController>().Play();
        }
            
    }
    public void AcceptMission() {
        if(Givers[_active].mission.goal.goalType == GoalType.Deliver || Givers[_active].mission.goal.goalType == GoalType.Handin)
            Givers[_active].AcceptMission();
        else
            Givers[_active].AcceptPuzzle();
    }
}
