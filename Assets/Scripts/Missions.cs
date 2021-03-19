using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[CreateAssetMenu(fileName = "New Mission", menuName = "Missions")]
[System.Serializable]
public abstract class Missions: ScriptableObject
{
    public  enum missionState
    {
        Upcoming,
        InProgress,
        Complited,
        Claimed
    }
    public int MissionId;
    public bool isActive;

    public string title;
    public string description;

    public bool RewardReady;
    public int rewardamount;
    public static int progress=0; //progress that shows id of current mission 

    public Goal goal;

    public Type type;

    public missionState state;

    public abstract void SetInfo();



    public void GainReward()
    {
        RewardReady = false;
        Debug.Log("reward was taken");
    }
    public void SetSTATE()
    {

        if (isActive == true & goal.currentAmount != goal.requiredAmount)
        {
             state = missionState.InProgress;
        }
        else if (goal.currentAmount==goal.requiredAmount)
        {
            state = missionState.Complited;
        }
        else if (MissionId>Missions.progress+1)
        {
            state = missionState.Claimed;
        }
        else { state = missionState.Upcoming; }
    }
    public void ShowMission()
    {
        if (type == Type.Kill)
        {
            description = "Kill " + goal.requiredAmount + " Zombies";  //for example zomboies
        }

        if (type == Type.Collect)
        {
            description = "Collect " + goal.requiredAmount + " Gems"; //for example gems
        }
    }
  //  public missionState state;

   
}
