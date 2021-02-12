using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionManager : MonoBehaviour
{
    public MissionGiver[] Givers;
    public List<GameObject> acari;

    public GameObject Healthbar;
    public GameObject Minimap;
    public GameObject DialogueCanvas;

    private int _active=0;

    private void Awake()
    {        
        Givers[_active].transform.gameObject.SetActive(true);
    }
    public void NextMission() {
        if (_active < Givers.Length - 1)      //Prossima missione
        {
            if (Givers[_active].questGoal.activeSelf)
                Givers[_active].questGoal.SetActive(false);

            

            _active++;
            Givers[_active].transform.gameObject.SetActive(true);
        }
        else     //Finite le missioni, passaggio a cutscene e scena successiva
        {
            if (Givers[_active].mission.goal.goalType == GoalType.Puzzle)
            {
                Time.timeScale = 1f;
                Givers[_active].puzzleWindow.SetActive(false);

                

            }
            if (Givers[_active].questGoal.activeSelf)
                    Givers[_active].questGoal.SetActive(false);

            foreach (GameObject acaro in acari)  //Distruggere tutti gli acari presenti nella scena
            {
                if (acaro != null)
                {
                    Destroy(acaro);
                }
            }
            gameObject.GetComponent<TimelineController>().Play();
            gameObject.GetComponent<DialogueTrigger>().TriggerDialogue();
            HandleUI();
        }
            
    }
    public void AcceptMission() {
        if(Givers[_active].mission.goal.goalType == GoalType.Deliver || Givers[_active].mission.goal.goalType == GoalType.Handin)
            Givers[_active].AcceptMission();
        else
            Givers[_active].AcceptPuzzle();
    }

    public void HandleUI()
    {
        Healthbar.SetActive(false);
        Minimap.SetActive(false);
        DialogueCanvas.SetActive(true);
    }
}
