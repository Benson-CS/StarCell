using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class applicationStateControl : MonoBehaviour
{
    private Control_Dominate sending;
    void Awake()
    {
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        sending.shotgunActive = false;
        sending.shieldActive = false;
        sending.mPActive = false;
        sending.nameReceived = false;
        sending.buttonPressed = false;
        sending.leaveReceived = false;
        sending.leaderReceived = false;
        sending.retryReceived = false;
        sending.currentAmmo = 0;
        sending.currentLevel = 1;
        sending.tokenCount = 0;
        sending.cloneAddingPew = 0;
        sending.currentAsteroid = 0;
    }
    void Update() { if (Input.GetKey("escape")) { Application.Quit(); } }
}