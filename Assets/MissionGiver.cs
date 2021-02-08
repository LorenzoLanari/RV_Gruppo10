using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionGiver : MonoBehaviour
{
    public Mission mission;
    public TPC_Rob Rob;
    public MissionFinisher Finisher;


    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;

    private void OnTriggerEnter(Collider other)
    {
        if(other == Rob.GetComponent<Collider>())
        {
            OpenQuestWindow();
            Time.timeScale = 0f;
        }
          
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);
        titleText.text = mission.title;
        descriptionText.text = mission.description;
    }

    public void AcceptMission()
    {
        questWindow.SetActive(false);
        mission.isActive = true;
        Rob.mission = mission;
        Time.timeScale = 1f;

        if(mission.goal.goalType == GoalType.Deliver)
           Instantiate(mission.Deliverable,mission.SpawnZone.position,Quaternion.identity);

        transform.gameObject.SetActive(false);
        Finisher.transform.gameObject.SetActive(true);
        Finisher.mission = mission;
        Finisher.Rob = Rob;
     
    }
}

