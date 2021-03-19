using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionEvent : MonoBehaviour
{
    
    private void Update()
    {

        if (missions.missionsList[Missions.progress].goal.IsChanged()==true  )  // SHOWS NEXT MISSION GOAL AS EVENT
        {
            descipteven.text= missions.missionsList[Missions.progress].description.ToString();
            currentvalue.text = missions.missionsList[Missions.progress].goal.currentAmount.ToString();
            requiredvaluse.text = missions.missionsList[Missions.progress].goal.requiredAmount.ToString();


            missionEvent.SetActive(true);
            missions.missionsList[Missions.progress].goal.trigger = false;
            missions.missionsList[Missions.progress].SetSTATE();

              StartCoroutine(EventTimer(3));
        }
        else if(missions.missionsList[Missions.progress].goal.IsReached())
        {
            missions.missionsList[Missions.progress].RewardReady = true;
            missions.missionsList[Missions.progress].isActive = false; 
            Missions.progress++; 
            missions.missionsList[Missions.progress].isActive = true;
            
        }
    }
    private void Start()
    {
        missions.missionsList[Missions.progress].isActive = true;
        missions.setid();
        missions.SetState();
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
    public void Kill()
    {
        if(missions.missionsList[Missions.progress].type== Type.Kill)
        missions.missionsList[Missions.progress].goal.EnemyKilled();
    }
    public void Collect()
    {
        if (missions.missionsList[Missions.progress].type == Type.Collect)
            missions.missionsList[Missions.progress].goal.ItemCollected();
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
    public void OnDestroys()
    {
        
        for (int i = 0; i < missions.missionsList.Count; i++)
        { GameObject obj = new GameObject();
            obj  = allMissions.transform.FindChild("Panel").GetComponentInChildren<Button>().gameObject;
            Destroy(obj);
           
        }
        allMissions.SetActive(false);
    }
    public void ShowMission() //show pannel with current mission
    {
     
      missionInfo.SetActive(true);
      titiletxt.text = missions.missionsList[Missions.progress].title;
      descriptiontxt.text = missions.missionsList[Missions.progress].description;
      goalCurrenttxt.text = missions.missionsList[Missions.progress].goal.currentAmount.ToString();
      goalRequiredtxt.text = missions.missionsList[Missions.progress].goal.requiredAmount.ToString();
      rewardtxt.text = missions.missionsList[Missions.progress].rewardamount.ToString();
    }


    IEnumerator EventTimer(float timeInSec)  // timer for envent of ending mission
    {

        yield return new WaitForSeconds(timeInSec);
        //сделать нужное
        missionEvent.SetActive(false);
        missions.SetState();
        

    }
}
