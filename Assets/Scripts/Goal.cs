using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Goal 
{
  // private MissionType missionType;
    public int requiredAmount;
    public int currentAmount;
    public bool trigger;    //for mission event trigger on changed currentvalues
    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }
    public bool IsChanged()
    {
        return (trigger);
    }
    public void DoMission()
    {
            currentAmount++;
            trigger = true;
    }

    /*
    public void EnemyKilled()
    {
        //if (missionType.missiontype == global::Type.Kill)
            currentAmount++;
        trigger = true;
    }
    public void ItemCollected()
    {
        //if (missionType.missiontype == global::Type.Collect)
            currentAmount++;
        trigger = true;
    }
    */
}
