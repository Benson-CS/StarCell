using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
// Original Script by JetPackDan
// Re-written by dnglchlk
//Re-worked by PhantomData87
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/

public class mainMenu : MonoBehaviour
{
    //Variables
    private Control_Dominate sending;
    // Declares sending var to Control_Dominate and invokes uh... fake update?
    void Awake()
    {
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        InvokeRepeating("update", 0f, 2f);
    }
    // Anyways this checks for ship death to be true and invokes countdown under conditions
    public void update()
    {
        //Checks if game has ended
        if (sending.didShipDie == true)
        {
            //Checks if name of player is saved
            if (sending.nameReceived == true)
            {
                //Checks if player choose to go to main menu
                if (sending.leaveReceived == true)
                {
                    SceneManager.LoadScene("leaderboard");
                    SceneManager.LoadScene("menuScreen");
                    sending.didShipDie = false;
                }
                //Checks if player choose to go to leaderboard
                else if (sending.leaderReceived == true)
                {
                    SceneManager.LoadScene("leaderboard");
                    sending.didShipDie = false;
                }
                //Checks if player wants to play game again
                else if (sending.retryReceived == true)
                {
                    SceneManager.LoadScene("leaderboard");
                    SceneManager.LoadScene("mainGameScene");
                    sending.didShipDie = false;

                }
            }
        }
    }
}