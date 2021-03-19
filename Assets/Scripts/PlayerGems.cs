using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerGems : MonoBehaviour
{
    // Start is called before the first frame update
    public Text Text;
    // Update is called once per frame
    void Update()
    {
        Text.text = "Player Gems:" + PlayerScript.gems;
    }
}
