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
  //  public int CurrentId; //progress that shows id of current mission 

    public Goal goal;

    public Type type;

    public missionState state;

    public abstract void SetInfo();

    public abstract void SetSTATE();

    public abstract void ShowMissionDesc();

    public void GainReward()
    {
        RewardReady = false;
        Debug.Log("reward was taken");
    }
    
    
  //  public missionState state;

   
}
