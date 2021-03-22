using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class MissionType : Missions
{
    public abstract void SetType();
    public override void SetInfo()
    {
        if (type == Type.Kill)
        {
            title = "Kill Mission";
            description = "Kill " + goal.requiredAmount + " Zombies";
        }
        else
        {
            title = "Collect Mission";
            description = "Collect " + goal.requiredAmount + " Gems";
        }
    }
    public override void SetSTATE()
    {

        if (isActive == true && goal.currentAmount != goal.requiredAmount)
        {
            state = missionState.InProgress;
          

        }
        else if (goal.currentAmount >= goal.requiredAmount)
        {
            state = missionState.Complited;
        }
      /*   else if (MissionId > )  //aka next mission .          Я до этого использовал статическую перменную ,Которая запоминала 
          {                                                                 // ,какой айди у нынешней миссии. из чего я сделал типа костыль ,который определяет claimed mission из параметра current id + 1. Но мне это не понравилось, 
              state = missionState.Claimed;                                 //  я переделал ,теперь это не работает :D
          }*/
        else { state = missionState.Upcoming; }
    }
    public override void ShowMissionDesc()
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
}

[CreateAssetMenu(fileName = "Kill Mission", menuName = "Missions/MissionType/KillMission")]
public class Kill : MissionType
{
    public override void SetType()
    {
        type = Type.Kill;
    }
}
[CreateAssetMenu(fileName = "Collect Mission", menuName = "Missions/MissionType/CollectMission")]
public class Collect : MissionType
{
    public override void SetType()
    {
        type = Type.Collect;
    }
}

public enum Type
{
    Kill,
    Collect
}