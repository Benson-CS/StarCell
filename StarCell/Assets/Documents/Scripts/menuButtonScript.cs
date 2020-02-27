using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
// Original script by JetPackDan
/* Re-Engineered. by the raccoon
      dP                   dP          dP       dP dP       
      88                   88          88       88 88       
.d888b88 88d888b. .d8888b. 88 .d8888b. 88d888b. 88 88  .dP  
88'  `88 88'  `88 88'  `88 88 88'  `"" 88'  `88 88 88888"   
88.  .88 88    88 88.  .88 88 88.  ... 88    88 88 88  `8b. 
`88888P8 dP    dP `8888P88 dP `88888P' dP    dP dP dP   `YP 
                       .88                                  
                   d8888P                                   
This figlet was here because I was bored not because I want to use it all the time*/
//Reworked compleatly by a phantom
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/
public class menuButtonScript : MonoBehaviour
{
    //Defining
    private GameObject enterName;
    private GameObject nameConfirm;
    private GameObject nameChange;
    private GameObject gameRetry;
    private GameObject openLeaderboard;
    private GameObject exitGame;
    private Control_Dominate sending;

    //Used to define variables
    void Awake()
    {
        //Defining
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        enterName = GameObject.Find("Put a name");
        nameConfirm = GameObject.Find("Confirm name");
        nameChange = GameObject.Find("Change name");
        gameRetry = GameObject.Find("Retry");
        openLeaderboard = GameObject.Find("Leaderbored");
        exitGame = GameObject.Find("Exit");
    }
    // This allows a UI button to set the active scene and loads the scene to the specified level
    public void switchActiveScene(string sceneChangeTo)
    {
        SceneManager.LoadScene(sceneChangeTo);
        Invoke("tokenSave", 0f);
    }
    // Initiates quit functions
    public void quitToDesktop() { Application.Quit(); }
    // Clears all scores from the leaderboard by setting values to zero and reloading scene
    public void clearAllScores()
    {
        // print to player "are you sure you want to clear all scores?"
        PlayerPrefs.SetInt("scoreline1", 0);
        PlayerPrefs.SetInt("scoreline2", 0);
        PlayerPrefs.SetInt("scoreline3", 0);
        PlayerPrefs.SetString("playerline1", "null");
        PlayerPrefs.SetString("playerline2", "null");
        PlayerPrefs.SetString("playerline3", "null");
        PlayerPrefs.SetInt("Scoring", 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // print to player "scores cleared"
    }
    //When this is active, it redirects player to the name prom
    public void changeNamePressed(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        //Variables are updated for other scripts
        sending.useSameName = false;
        sending.nameReceived = false;
        //GUI changes
        nameConfirm.SetActive(false);
        nameChange.SetActive(false);
        gameRetry.SetActive(false);
        openLeaderboard.SetActive(false);
        exitGame.SetActive(false);
        enterName.SetActive(true);
    }
    public void question(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        var z = GameObject.Find("playerInputText").GetComponent<Text>();
        //Saves current name
        sending.gameName = z.text;
        //GUI changes
        enterName.SetActive(false);
        nameConfirm.SetActive(true);
    }
    public void saveNamePressed(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        //Script variable changes for other scripts
        sending.useSameName = true;
        //GUI changes
        enterName.SetActive(false);
        nameConfirm.SetActive(false);
        nameChange.SetActive(true);
        gameRetry.SetActive(true);
        openLeaderboard.SetActive(true);
        exitGame.SetActive(true);
    }
    public void rejectSaveName(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        //Script variable changes for other scripts
        sending.useSameName = false;
        //GUI changes
        enterName.SetActive(false);
        nameConfirm.SetActive(false);
        nameChange.SetActive(true);
        gameRetry.SetActive(true);
        openLeaderboard.SetActive(true);
        exitGame.SetActive(true);
    }
    public void menu(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        //Saves name or keeps currently saved name
        PlayerPrefs.SetString("player", sending.gameName);
        //Saves game score
        PlayerPrefs.SetInt("Scoring", sending.gameScore);
        //Script variable changes for other scripts
        sending.leaveReceived = true;
        sending.nameReceived = true;
    }
    public void game(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        //Saves name or keeps currently saved name
        PlayerPrefs.SetString("player", sending.gameName);
        //Saves game score
        PlayerPrefs.SetInt("Scoring", sending.gameScore);
        //Script variable changes for other scripts
        sending.retryReceived = true;
        sending.nameReceived = true;
    }
    public void leader(bool a)
    {
        //Defining
        Invoke("tokenSave", 0f);
        var sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        //Saves name or keeps currently saved name
        PlayerPrefs.SetString("player", sending.gameName);
        //Saves game score
        PlayerPrefs.SetInt("Scoring", sending.gameScore);
        //Script variable changes for other scripts
        sending.leaderReceived = true;
        sending.nameReceived = true;
    }
    public void tokenSave()
    {
        PlayerPrefs.SetInt("currency", sending.currency);
        if (sending.tokenSaveDebug == true) { UnityEngine.Debug.Log("Tokens Saved!"); }
    }
}
