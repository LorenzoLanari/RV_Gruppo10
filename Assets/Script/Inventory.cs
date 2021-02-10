using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public MissionFinisher finisher;

    public Slot[] slots;

    private void Update()
    {
        if (slots[0].RightItem() && slots[1].RightItem() && slots[2].RightItem() && slots[3].RightItem())
        {
            finisher.MissionComplete();
          
        }
       
    }



}

