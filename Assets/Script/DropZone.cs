using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropZone : MonoBehaviour
{
    public GameObject Box;
    private MissionFinisher finisher;
    private void Start()
    {
        Box = GameObject.FindGameObjectWithTag("Pickable");
        finisher = GetComponentInParent<MissionFinisher>();
    }

    private void OnTriggerEnter(Collider other)
    {
       if (finisher.mission.goal.goalType == GoalType.Deliver)
        {
            if (other == Box.GetComponent<Collider>())
            {
           
                Box.GetComponent<Pickable>().SetCanDrop(true);
            }

        }
       else if(finisher.mission.goal.goalType == GoalType.Handin)
        {
            
            if (other == finisher.Rob.GetComponent<Collider>())
            {
                if (finisher.Rob.collected)
                {
                    finisher.mission.goal.ItemCollected();
                    finisher.Rob.collected = false;
                    if (finisher.mission.goal.IsReached())
                    {
                        finisher.MissionComplete();
                    }
                    else
                    {
                        finisher.mission.SpawnZone.Spawn();
                    }

                }
                
            }

        }
       

    }
}
