using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MissionGoal 
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public string toolTip;
    public Text var;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemCollected()
    {
        if(goalType == GoalType.Deliver || goalType == GoalType.Handin)
        {
           currentAmount++;
           var.text =  currentAmount.ToString();
        }
           
    }

}

public enum GoalType
{
    Deliver,
    Handin,
    Puzzle
}
