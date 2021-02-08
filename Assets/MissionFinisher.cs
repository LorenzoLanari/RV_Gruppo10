using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionFinisher : MonoBehaviour
{
    public Mission mission;
    public TPC_Rob Rob;
    public GameObject missionComplete;

    public void MissionComplete()
    {
        mission.isActive = false;
        missionComplete.SetActive(true);

    }
}
