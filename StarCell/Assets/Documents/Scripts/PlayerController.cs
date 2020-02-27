using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made by dnglchlk & PhantomData87
/*
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                        /
\|
*/
/*

      dP                   dP          dP       dP dP          
      88                   88          88       88 88          
.d888b88 88d888b. .d8888b. 88 .d8888b. 88d888b. 88 88  .dP     
88'  `88 88'  `88 88'  `88 88 88'  `"" 88'  `88 88 88888"      
88.  .88 88    88 88.  .88 88 88.  ... 88    88 88 88  `8b. dP 
`88888P8 dP    dP `8888P88 dP `88888P' dP    dP dP dP   `YP 88 
                       .88                                  .P 
                   d8888P                                      
*/
public class PlayerController : MonoBehaviour
{

    Rigidbody rb;
    private Control_Dominate sending;
    private float startTurn;
    private float speed;
    private float maxTurn;
    private float memSpeeds;
    public bool objectAttachedIsShip = true;

    void Awake()
    {
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        startTurn = sending.startTurn;
        speed = sending.speed;
        maxTurn = sending.maxTurn;
        memSpeeds = startTurn;
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Acts like void Update(), only this time, it's isolated
        InvokeRepeating("Timer", 0.0f, 0.5f);
    }
    //Updates every new tick
    void FixedUpdate()
    {
        //changes position only if this is ship
        if (objectAttachedIsShip == true)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            //Speed/Going foward
            rb.AddForce(new Vector3(-speed, 0.0f, 0.0f));
            //Movement
            rb.AddForce(new Vector3(0.0f, moveVertical, moveHorizontal) * startTurn);
        }
    }
    //A timer started at void Start()
    void Timer()
    {
        //Isolated varaible for memory
        float x = startTurn;
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            //Detects the highest turn value possible
            if (x - 1 <= maxTurn)
            {
                //Debug.Log("Key input recieved!");
                x = x + 1f;
                startTurn = x;
            }
        }
        //Resets turn value back to original turn speeds
        else
        {
            //Debug.Log("No key input");
            startTurn = memSpeeds;
        }
    }
}
