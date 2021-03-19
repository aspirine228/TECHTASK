using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New List", menuName = "MissionList")]
[System.Serializable]
public class MissionsData : ScriptableObject
{
    public List<Missions> missionsList = new List<Missions>();

    public void setid()
    {
     
        for(int i=0; i < missionsList.Count; i++)
        {
            missionsList[i].MissionId = i;
            missionsList[i].SetSTATE();
        }
    }
    public void SetState()
    {

        for (int i = 0; i < missionsList.Count; i++)
        {
           
            missionsList[i].SetSTATE();
            missionsList[i].SetInfo();
        }
    }
}
