using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnZone : MonoBehaviour
{
    public Mission mission;

    public void Spawn()
    {
        Instantiate(mission.Deliverable, transform.position, Quaternion.identity);
    }
}
