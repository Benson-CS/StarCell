using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//By PhantomData87
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/
public class Invensible : MonoBehaviour
{
    private Control_Dominate sending;
    void Awake()
    {
        //Defines basic variables
        //Makes sure it cannot be destroyed in other scenes
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        InvokeRepeating("update",0f,.5f);
        if(SceneManager.sceneCount != 1)
        {
            SceneManager.LoadScene("Intro loading");
        }
        DontDestroyOnLoad(this);

    }
    //Verification
    void update()
    {
        if(sending.earlyNameMaybeDone == true)
        {
            //Loads the game's title
            SceneManager.LoadScene("menuScreen");
            CancelInvoke("update");
        }
    }
    //To skip adding a name
    public void skipEarlyName(bool a)
    {
        //Update variables
        sending.earlyNameMaybeDone = true;
    }
    //To save a name
    public void newEarlyName(bool a)
    {
        //Defining
        var z = GameObject.Find("playerInputText").GetComponent<Text>();
        //Saves current name
        sending.gameName = z.text;
        sending.useSameName = true;
        //Saves player name
        PlayerPrefs.SetString("player", sending.gameName);
        //Update variables
        sending.nameReceived = true;
        sending.earlyNameMaybeDone = true;
    }
    public void tokenGet()
    {
        sending.currency = PlayerPrefs.GetInt("currency");
        if (sending.tokenSaveDebug == true) { UnityEngine.Debug.Log("Tokens Retrieved"); }
    }
}
