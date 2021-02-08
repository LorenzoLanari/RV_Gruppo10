using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MissionGoal 
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;
    public string toolTip;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void ItemCollected()
    {
        if(goalType == GoalType.Deliver)
            currentAmount++;
    }

}

public enum GoalType
{
    Deliver,
    Puzzle
}
