using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionEvent : MonoBehaviour
{
    
  
    private void Start()
    {

        missions.setid();
        missions.SetState();
        missions.missionsList[missions.Currentid].isActive = true;
    }
    // public Missions mission;

    public MissionsData missions;
    public GameObject missionInfo;
    public GameObject allMissions;
    public GameObject missionEvent;
    public GameObject prefabs;
    public GameObject sp;
    //------for event--------
    public Text currentvalue;
    public Text requiredvaluse;
    public Text descipteven;
    //----for current mission-----
    public Text titiletxt;
    public Text descriptiontxt;
    public Text goalCurrenttxt;
    public Text goalRequiredtxt;
    public Text rewardtxt;
    public void UpdateInfo()
    {
       missions.missionsList[missions.Currentid].isActive = true;
       missions.setid();
       missions.SetState();
        if (missions.missionsList[missions.Currentid].goal.IsChanged() == true)  // SHOWS NEXT MISSION GOAL AS EVENT
        {
            descipteven.text = missions.missionsList[missions.Currentid].description.ToString();
            currentvalue.text = missions.missionsList[missions.Currentid].goal.currentAmount.ToString();
            requiredvaluse.text = missions.missionsList[missions.Currentid].goal.requiredAmount.ToString();


            missionEvent.SetActive(true);
            missions.missionsList[missions.Currentid].goal.trigger = false;
            missions.missionsList[missions.Currentid].SetSTATE();

            StartCoroutine(EventTimer(3));
        }
        else if (missions.missionsList[missions.Currentid].goal.IsReached())
        {
            missions.missionsList[missions.Currentid].RewardReady = true;
            missions.missionsList[missions.Currentid].isActive = false;
            missions.Currentid++;
            missions.missionsList[missions.Currentid].isActive = true;
            StartCoroutine(EventTimer(3));
        }
    }
    public void Kill()
    {
        if (missions.missionsList[missions.Currentid].type == Type.Kill)
        { missions.missionsList[missions.Currentid].goal.DoMission(); }
        UpdateInfo();
    }
    public void Collect()
    {
        if (missions.missionsList[missions.Currentid].type == Type.Collect)
        { missions.missionsList[missions.Currentid].goal.DoMission(); }
        UpdateInfo();
    }
   
    public void ShowAll()  //shows pannel with list of missions
    {
        allMissions.SetActive(true);
        for(int i=0;i< missions.missionsList.Count; i++)
        {
            GameObject obj = Instantiate(prefabs, new Vector2(0, 0), Quaternion.identity) as GameObject;
            obj.transform.SetParent(sp.transform);
            obj.transform.localScale = new Vector2(1, 1);
            obj.name =  i.ToString();
            
            obj.GetComponentInChildren<Text>().text = missions.missionsList[i].title;
            obj.transform.FindChild("Text").GetComponentInParent<Text>().text = missions.missionsList[i].state.ToString();
        }
    }
    public void OnDestroys() //тут я пытаюсь уничтожить префабы миссий ,потому при открытии списка миссиий они создаются заново ,но они не уничтожаются ( 
    {
        for (int i = 0; i < missions.missionsList.Count; i++)
        { GameObject obj ;
            obj  = allMissions.transform.FindChild("Panel").GetComponentInChildren<Button>().gameObject;
            Destroy(obj);
           
        }
        allMissions.SetActive(false);
    }
    public void ShowMission() //show pannel with current mission
    {
        //UpdateInfo();
        missionInfo.SetActive(true);
      titiletxt.text = missions.missionsList[missions.Currentid].title;
      descriptiontxt.text = missions.missionsList[missions.Currentid].description;
      goalCurrenttxt.text = missions.missionsList[missions.Currentid].goal.currentAmount.ToString();
      goalRequiredtxt.text = missions.missionsList[missions.Currentid].goal.requiredAmount.ToString();
      rewardtxt.text = missions.missionsList[missions.Currentid].rewardamount.ToString();
    }


    IEnumerator EventTimer(float timeInSec)  // timer for envent of ending mission
    {
        yield return new WaitForSeconds(timeInSec);
        //сделать нужное
        missionEvent.SetActive(false);
        missions.SetState();
        UpdateInfo();
    }
}
