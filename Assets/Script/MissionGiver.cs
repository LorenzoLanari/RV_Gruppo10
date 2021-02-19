using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;


public class MissionGiver : MonoBehaviour
{
    public Mission mission;
    public TPC_Rob Rob;
    public MissionFinisher Finisher;
    public GameObject puzzleWindow;
    public GameObject questWindow;
    public GameObject questGoal;
    public Text titleText;
    public Text descriptionText;
    public Text fisso;
    public Text variabile;
    private float StartPositionY;

    private void Start()
    {
        StartPositionY = transform.position.y;
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMoveY(StartPositionY + 1.5f, 2f));
        moveSequence.Append(transform.DOMoveY(StartPositionY , 2f));
        moveSequence.SetLoops(-1);
        moveSequence.Play();
    }
   
    private void OnTriggerEnter(Collider other)
    {
        if(other == Rob.GetComponent<Collider>())
        {
            FindObjectOfType<AudioManager>().Play("QuestPopup");
            OpenQuestWindow();
            Time.timeScale = 0f;
        }
          
    }

    public void OpenQuestWindow()
    {
        Cursor.visible = true;
        questWindow.SetActive(true);
        titleText.text = mission.title;
        descriptionText.text = mission.description;
    }

    public void AcceptMission()
    {
        Cursor.visible = false;
        questWindow.SetActive(false);
        mission.isActive = true;
        Rob.mission = mission;
        Time.timeScale = 1f;
        
        mission.SpawnZone.mission = mission;
        mission.SpawnZone.Spawn();
       
        questGoal.SetActive(true);
        fisso.text = mission.goal.toolTip;
        variabile.text =  mission.goal.currentAmount.ToString() + " / " + mission.goal.requiredAmount.ToString(); 
        transform.gameObject.SetActive(false);
        Finisher.transform.gameObject.SetActive(true);
        Finisher.mission = mission;
        Finisher.Rob = Rob;     
    }
    public void AcceptPuzzle() {
        questWindow.SetActive(false);
        mission.isActive = true;
        Rob.mission = mission;
        puzzleWindow.SetActive(true);
        Finisher.transform.gameObject.SetActive(true);
        Finisher.mission = mission;
        Finisher.Rob = Rob;
        questGoal.SetActive(true);
        fisso.text = mission.goal.toolTip + " " + mission.goal.requiredAmount;
        variabile.text = mission.goal.currentAmount.ToString();
        transform.gameObject.SetActive(false);
    }
}

