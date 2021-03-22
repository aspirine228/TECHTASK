using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[System.Serializable]
public class PlayerScript : MonoBehaviour
{
   
    public int health = 5;
    public static int gems = 0;
    public MissionsData missions;
    public void TakeReward() //да , я тут почему-то работаю с именами объектов ,вместо их айди из списка. мне было так удобнее (
    {
        //GameObject obj = new GameObject();
        if (missions.missionsList[Convert.ToInt32(gameObject.name)].goal.IsReached())
        {

            if (missions.missionsList[Convert.ToInt32(gameObject.name)].RewardReady)
            {
                gems += missions.missionsList[Convert.ToInt32(gameObject.name)].rewardamount;

                missions.missionsList[Convert.ToInt32(gameObject.name)].GainReward();
            }
        }
    }
}
