using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
// --- Made by dnglchlk and wrote every word here so blame him ---
/* 
  above comment written by PhantomData87 because
  dnglchlk won't remove name for better understanding in the future
*/
// modified by PhantomData87
public class timeScoreManager : MonoBehaviour
{
    public bool continueProcessing;
    public int minScoreOnAsteroidHit;
    public int maxScoreOnAsteroidHit;
    private int timeSeconds = 0;
    private int timeMinutes = 0;
    private float timeMilliseconds = 0;
    [Tooltip("Enables the flooding of debug messages printing score to console")]
    public bool scoreDebugDeath;
    [Tooltip("Enables the flooding of debug messages printing time to console")]
    public bool timeDebugDeath;
    [Tooltip("Controls how much score will be added to scoring every updateRate")]
    [Range(0, 3)] public int scoreAdd;
    private Text txt;
    private Text tme;
    private Text centerpanel;
    private Text centerpanel1;
    private Text centerpanel2;
    private Text centerpanel3;
    private Text centerpanel4;
    private Text centerpanel5;
    private Text centerpanel6;
    private Text centerpanel7;
    private Text centerpanel8;
    private Text centerpanel9;
    private string scoreDisplay;
    [Tooltip("Allows dev to change time it takes for another scoreAdd to be added to scoring")]
    public float updateRate;
    private float tenPercent;
    private float twentyPercent;
    private float thirtyPercent;
    private float fortyPercent;
    private float fiftyPercent;
    private float sixtyPercent;
    private float seventyPercent;
    private float eightyPercent;
    private float ninetyPercent;
    private float floatAmmo;
    private Control_Dominate sending;
    private float floatMaxAmmo;
    private GameObject cp1;
    private GameObject cp2;
    private GameObject cp3;
    private GameObject cp4;
    private GameObject cp5;
    private GameObject cp6;
    private GameObject cp7;
    private GameObject cp8;
    private GameObject cp9;
    private GameObject cp10;

    [HideInInspector]
    public int scoring;
    // Start is called before the first frame update

    //sets txt ui to 0 instead of default
    void Start()
    {
        // Defines bar gameObjects to use with bar
        cp1 = GameObject.Find("centerpanel");
        cp2 = GameObject.Find("centerpanel1");
        cp3 = GameObject.Find("centerpanel2");
        cp4 = GameObject.Find("centerpanel3");
        cp5 = GameObject.Find("centerpanel4");
        cp6 = GameObject.Find("centerpanel5");
        cp7 = GameObject.Find("centerpanel6");
        cp8 = GameObject.Find("centerpanel7");
        cp9 = GameObject.Find("centerpanel8");
        cp10 = GameObject.Find("centerpanel9");
        // Declares what Control_Dominate is linked to
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        // Gets Max Ammo from Control_Dominate
        floatMaxAmmo = sending.ammo;
        // This calculates all of the percentages for the bar to check with
        tenPercent = floatMaxAmmo * 0.1f;
        twentyPercent = floatMaxAmmo * 0.2f;
        thirtyPercent = floatMaxAmmo * 0.3f;
        fortyPercent = floatMaxAmmo * 0.4f;
        fiftyPercent = floatMaxAmmo * 0.5f;
        sixtyPercent = floatMaxAmmo * 0.6f;
        seventyPercent = floatMaxAmmo * 0.7f;
        eightyPercent = floatMaxAmmo * 0.8f;
        ninetyPercent = floatMaxAmmo * 0.9f;
        //txt and tme represent text components that are displayed on-screen as ui
        txt = GameObject.Find("txt").GetComponent<Text>();
        tme = GameObject.Find("tme").GetComponent<Text>();
        //ammo meter
        txt.text = "Score: " + scoring;
        //sets timers for score and time adding
        InvokeRepeating("ScoreAdding", 0f, updateRate);
        InvokeRepeating("stopwatchRun", 0f, 0.01f);
        InvokeRepeating("barUpdate", 0.0f, 0.1f);
    }
    // This method is responsible for adding constant game score as player moves
    void ScoreAdding()
    {
        if (continueProcessing == true)
        {
            scoring = scoring + scoreAdd;
            if (scoreDebugDeath == true) { UnityEngine.Debug.Log(scoring); }
        }
    }
    // Update is called once per frame
    // Update calles the UI refresh
    void Update()
    {
        floatAmmo = sending.currentAmmo;
        tme.text = $"Time {timeMinutes.ToString("D2")}:{timeSeconds.ToString("D2")}.{timeMilliseconds}";
        txt.text = $"Score: {scoring}";
        sending.gameScore = scoring;
    }
    // This is the method used to control the keeping of time
    void stopwatchRun()
    {
        if (continueProcessing == true)
        {
            /*when time in seconds is 60, add 1 minute*/
            if (timeSeconds == 59) { timeSeconds = 0; ++timeMinutes; }
            /*same method for milliseconds*/
            if (timeMilliseconds == 99) { timeMilliseconds = 0; ++timeSeconds; }
            //every millisecond add a millisecond to game timer
            ++timeMilliseconds;
            //use if you want stopwatch hell in console
            if (timeDebugDeath == true) { UnityEngine.Debug.Log($"Stopwatch is now {timeMinutes}:{timeSeconds}.{timeMilliseconds}"); }
        }
    }
    // On a pellet hitting an asteroid this method occurs to give player score
    void asteroidhit() { scoring = scoring + UnityEngine.Random.Range(minScoreOnAsteroidHit, maxScoreOnAsteroidHit); }
    // This method is responsible for checking active ammo level against the level of the bar
    // to determine whether or not to enable or disable a portion of it
    void barUpdate()
    {
        if (floatAmmo >= tenPercent) { cp1.SetActive(true); } else { cp1.SetActive(false); }
        if (floatAmmo >= twentyPercent) { cp2.SetActive(true); } else { cp2.SetActive(false); }
        if (floatAmmo >= thirtyPercent) { cp3.SetActive(true); } else { cp3.SetActive(false); }
        if (floatAmmo >= fortyPercent) { cp4.SetActive(true); } else { cp4.SetActive(false); }
        if (floatAmmo >= fiftyPercent) { cp5.SetActive(true); } else { cp5.SetActive(false); }
        if (floatAmmo >= sixtyPercent) { cp6.SetActive(true); } else { cp6.SetActive(false); }
        if (floatAmmo >= seventyPercent) { cp7.SetActive(true); } else { cp7.SetActive(false); }
        if (floatAmmo >= eightyPercent) { cp8.SetActive(true); } else { cp8.SetActive(false); }
        if (floatAmmo >= ninetyPercent) { cp9.SetActive(true); } else { cp9.SetActive(false); }
        if (floatAmmo >= floatMaxAmmo) { cp10.SetActive(true); } else { cp10.SetActive(false); }
    }

}