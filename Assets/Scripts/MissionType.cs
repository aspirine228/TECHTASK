using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Mission", menuName = "Missions/KillMission")]
[System.Serializable]
public class MissionType : Missions
{

    
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




}
public enum Type
{
    Kill,
    Collect
}