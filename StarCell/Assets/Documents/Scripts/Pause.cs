using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Pause : MonoBehaviour
{
    //Defining
    private Control_Dominate sending;
    // Update is called once per frame
    void Awake()
    {
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
    }
    void Update()
    {
        //Waits for key input
        if (Input.GetKeyDown(sending.pauseButton.ToLower()))
        {
            //If game is running, it now pauses it
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            //If game is paused, it runs the game
            else
            {
                Time.timeScale = 1;
            }
        }
    }
    
}
