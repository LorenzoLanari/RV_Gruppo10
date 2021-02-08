using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Mission
{
    public bool isActive;

    public string title;
    public string description;
    public SpawnZone SpawnZone;
    public GameObject Deliverable;

    public MissionGoal goal;

   
}
