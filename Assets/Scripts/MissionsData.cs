using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New List", menuName = "MissionList")]
[System.Serializable]
///Думаю проще было бы создать спикок в другом классе, вместо создания отдельного класса для списка. Этот класс практически ничего не делает.

public class MissionsData : ScriptableObject
{
    public List<Missions> missionsList = new List<Missions>();
    //  public delegate int SetCurrentId(int CurrentId);
    public int Currentid;
    public void setid()
    {
        for(int i=0; i < missionsList.Count; i++)
        {
            missionsList[i].MissionId = i;
            // missionsList[i].SetSTATE();
            
        }
    }

    public void SetState()
    {

        for (int i = 0; i < missionsList.Count; i++)
        {
            
            missionsList[i].SetSTATE();   
            missionsList[i].SetInfo();
            if(missionsList[i].isActive)
            Currentid = missionsList[i].MissionId;
            

        }
    }
}
