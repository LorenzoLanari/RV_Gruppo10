using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Mission 
{
    public bool isActive;

    public string title;

    [TextArea(3,15)]
    public string description;
    public SpawnZone SpawnZone;
    public GameObject Deliverable;

    public MissionGoal goal;

   
}
