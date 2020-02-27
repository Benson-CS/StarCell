using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// script made by dnglchlk
// very heavily modified by
/*
       _                                                            _______
      | |                                        |                 /  \   /
   _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
 |/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
 |__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                        /
\|                              
 */
public class powerupCol : MonoBehaviour
{
    //Defining
    private string ship = "ship3v8";
    private Control_Dominate sending;
    public bool powerupEnable;


    void Awake() {/*Defines variables for Control_Panel*/sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>(); }

    //If something collided with it
    void OnCollisionEnter(Collision boom)
    {
        //Verifying ships name
        if (boom.gameObject.name == ship)
        {
            //Verifying if powerups are enabled
            if (powerupEnable == true)
            {
                //Checking for powerup tag
                if (gameObject.tag == "Shotgun") {/*Allows this powerup enabled*/sending.shotgunActive = true; }
                /*Checking for powerup tag*/
                else if (gameObject.tag == "Shield") {/*Allows this powerup enabled*/sending.shieldActive = true; }
                /*Checking for powerup tag*/
                else if (gameObject.tag == "MP") {/*Allows this powerup enabled*/sending.mPActive = true; }
                //Finally destroys object itself
                Destroy(gameObject);
            }
            else { Debug.LogError("Powerups are not enabled! This is not supposed to happen!"); }
        }
    }

}
