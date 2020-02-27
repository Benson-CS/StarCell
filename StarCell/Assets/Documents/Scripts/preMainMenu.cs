using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Mainly done by PhantomData87
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/
public class preMainMenu : MonoBehaviour
{
    //Defining
    private Control_Dominate sending;
    private GameObject a;
    private GameObject b;
    private GameObject c;
    private GameObject d;
    private GameObject e;
    private GameObject f;
    private GameObject g;
    private GameObject h;
    private int i;
    private int ii;

    //Some void that is left here for no reason
    public void buttonPressed()
    { i = 1; }
    // Start is called before the first frame update
    public void Start()
    {
        //Defining
        i = 0;
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        a = GameObject.Find("Cav 1");
        b = GameObject.Find("Cav 2");
        c = GameObject.Find("Put a name");
        d = GameObject.Find("Confirm name");
        e = GameObject.Find("Change name");
        f = GameObject.Find("Retry");
        g = GameObject.Find("Leaderbored");
        h = GameObject.Find("Exit");
        b.SetActive(false);
        //Verification
        InvokeRepeating("update", 0f, .5f);
    }
    public void update()
    {
        //Checks if game has ended
        if (sending.didShipDie == true && i == 0)
        {
            //Changes current GUI
            a.SetActive(false);
            b.SetActive(true);
            //Checks if player op't to use same name
            if (sending.useSameName == true)
            {
                //GUI changes
                c.SetActive(false);
                d.SetActive(false);
                //Variable changes to go to quicker selection
                sending.nameReceived = true;
                //Stops this script
                CancelInvoke("update");
            }
            //Checks if player has no name set
            else if(sending.useSameName == false)
            {
                //GUI changes
                d.SetActive(false);
                e.SetActive(false);
                f.SetActive(false);
                g.SetActive(false);
                h.SetActive(false);
                //Stops this script
                CancelInvoke("update");
            }
        }
    }
}
