using System.Diagnostics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class leaderboardScores : MonoBehaviour
{
    private int topscore;
    private int numbertwo;
    private int numberthree;
    private int scoring;
    private Control_Dominate sending;
    private Text scoreline1;
    private Text scoreline2;
    private Text scoreline3;
    private string player;
    private string playerline1;
    private string playerline2;
    private string playerline3;


    // Made by dnglchlk because i'm a big boy and I can do things myself
    void Awake()
    {
        // Links variables from always active variable store to this script
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        scoreline1 = GameObject.Find("scoreline1").GetComponent<Text>();
        scoreline2 = GameObject.Find("scoreline2").GetComponent<Text>();
        scoreline3 = GameObject.Find("scoreline3").GetComponent<Text>();
        // Getting game score from Control_Dominate
        scoring = PlayerPrefs.GetInt("Scoring");
        player = PlayerPrefs.GetString("player");
        // Retrieve previous scores if any
        playerline1 = PlayerPrefs.GetString("playerline1");
        playerline2 = PlayerPrefs.GetString("playerline2");
        playerline3 = PlayerPrefs.GetString("playerline3");
        // Re-sets leaderboard values to previous entries
        topscore = PlayerPrefs.GetInt("scoreline1");
        numbertwo = PlayerPrefs.GetInt("scoreline2");
        numberthree = PlayerPrefs.GetInt("scoreline3");
        // Re-sets leaderboard players to previous entries
        //
        //**
        // Removed null setter because of bugs
        //**
        //
        /* If scoring is greater than the current high score 
        delete the third value and place new score at top while moving others down */
        if (scoring > topscore)
        {
            numberthree = numbertwo;
            numbertwo = topscore;
            topscore = scoring;
            playerline1 = PlayerPrefs.GetString("player");
            playerline2 = PlayerPrefs.GetString("playerline1");
            playerline3 = PlayerPrefs.GetString("playerline2");
        }
        // If scoring is greater than scoreline 2 and smaller than scoreline1 then place score in scoreline2
        else if (scoring > numbertwo && scoring < topscore)
        {
            numberthree = numbertwo;
            numbertwo = scoring;
            playerline2 = PlayerPrefs.GetString("player");
            playerline3 = PlayerPrefs.GetString("playerline2");

        }
        /* If scoring is greater than board value 3, and less than board value 2 and 1,
        overwrite value 3 with total score */
        else if (scoring > numberthree && scoring < numbertwo && scoring < topscore)
        {
            numberthree = scoring;
            playerline3 = PlayerPrefs.GetString("playerline3");
            PlayerPrefs.SetString("playerline3", playerline3);

        }
        else
        {
            playerline1 = PlayerPrefs.GetString("playerline1");
            playerline2 = PlayerPrefs.GetString("playerline2");
            playerline3 = PlayerPrefs.GetString("playerline3");
            //UI Print YOU DIDNT SET A HIGH SCORE!
        }

        // Sets all values after changes for next load
        PlayerPrefs.SetInt("scoreline1", topscore);
        PlayerPrefs.SetInt("scoreline2", numbertwo);
        PlayerPrefs.SetInt("scoreline3", numberthree);
        PlayerPrefs.SetString("playerline1", playerline1);
        PlayerPrefs.SetString("playerline2", playerline2);
        PlayerPrefs.SetString("playerline3", playerline3);
        PlayerPrefs.SetInt("Scoring", 0);
        scoreline1.text = $"1. {playerline1} {topscore}";
        scoreline2.text = $"2. {playerline2} {numbertwo}";
        scoreline3.text = $"3. {playerline3} {numberthree}";

    }
}
