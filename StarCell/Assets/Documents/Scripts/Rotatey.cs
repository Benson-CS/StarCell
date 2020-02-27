using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Made by PhantomData87
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                        /
\|
*/
// monumental size reductions made by dnglchlk
public class Rotatey : MonoBehaviour
{
    //Defining
    private Control_Dominate sending;
    //By Control_Dominate
    private float rotateMaxHA;
    private float rotateMaxY;
    private float rotateMaxVA;
    private float resistChange;
    private float constantChange;
    private float noKeyDrag;
    //Non static variables
    private float currentVAxis;
    private float currentHAxis;
    private float currentYxis;
    //Saved variables for reference
    private float memSpeedX;
    private float memSpeedY;
    private float memSpeedZ;
    //Used for joystick
    private float moveHorizontal;
    private float moveVertical;

    void Awake()
    {
        //Defining
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        rotateMaxHA = sending.rotateMaxHA;
        rotateMaxY = sending.rotateMaxY;
        rotateMaxVA = sending.rotateMaxVA;
        resistChange = sending.resistChange;
        constantChange = sending.constantChange;
        noKeyDrag = sending.noKeyDrag;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Set variables
        memSpeedX = currentHAxis;
        memSpeedY = currentYxis;
        memSpeedZ = currentVAxis;
        //starts a nice named timer
        InvokeRepeating("RotateyShipX", 0.0f, 0.01f);
        InvokeRepeating("RotateyShipY", 0.0f, 0.01f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Rotation
        Quaternion myRotation = Quaternion.identity;
        var someValue = new Vector3(-currentHAxis, currentYxis, -currentVAxis);
        myRotation.eulerAngles = someValue;
        transform.rotation = myRotation;
        //Joystick
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
    }
    //The glorious method defined right here
    void RotateyShipX()
    {
        //Isolated variable for memory
        if (Input.GetKey(KeyCode.A) || moveHorizontal < 0)
        { //Detects the highest turn value possible
            if (currentHAxis < rotateMaxHA)
            {
                currentHAxis = currentHAxis + constantChange;
                //Constant to change
                if (-currentHAxis > 0) { currentHAxis = currentHAxis - resistChange;/*Incase their instantly changing direction*/}
            }
        }
        else if (Input.GetKey(KeyCode.D) || moveHorizontal > 0)
        { //Detects the highest turn value possible
            if (currentHAxis > -rotateMaxHA)
            {
                currentHAxis = currentHAxis - constantChange;
                if (currentHAxis > 0) {/*Incase their instantly changing direction*/currentHAxis = currentHAxis + resistChange; }
            }
            else if (currentHAxis >= -rotateMaxHA) {/*Constant to change*/currentHAxis = currentHAxis - constantChange; }
        }
        else
        {
            //Resets rotation of technoblade
            if (currentHAxis > memSpeedX) { currentHAxis = currentHAxis - noKeyDrag; }
            //Resets rotation of ship
            else if (-currentHAxis > memSpeedX) { currentHAxis = currentHAxis + noKeyDrag; }
        }
    }
    void RotateyShipY()
    {
        //Checks for key input
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            if (currentVAxis >= -rotateMaxVA) { currentVAxis = currentVAxis - constantChange; }
            if (currentYxis >= -rotateMaxY) { currentYxis = currentYxis - constantChange; }
        }
        //Checks for joystick movement
        else if (moveHorizontal < 0 && moveVertical < 0)
        {
            if (currentVAxis >= -rotateMaxVA) { currentVAxis = currentVAxis - constantChange; }
            if (currentYxis >= -rotateMaxY) { currentYxis = currentYxis - constantChange; }
        }
        //Checks for key input
        else if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.D))
        {
            if (currentVAxis >= -rotateMaxVA) { currentVAxis = currentVAxis - constantChange; }
            if (currentYxis <= rotateMaxY) { currentYxis = currentYxis + constantChange; }
        }
        //Checks for joystick movement
        else if (moveHorizontal > 0 && moveVertical < 0)
        {
            if (currentVAxis >= -rotateMaxVA) { currentVAxis = currentVAxis - constantChange; }
            if (currentYxis <= rotateMaxY) { currentYxis = currentYxis + constantChange; }
        }
        //Checks for input
        else if (Input.GetKey(KeyCode.W) || moveVertical > 0)
        {
            if (currentVAxis < rotateMaxVA)
            {
                currentVAxis = currentVAxis + constantChange;
                //Constant to change
                if (-currentVAxis > 0) {/*Incase their instantly changing direction*/ currentVAxis = currentVAxis - resistChange; }
            }
        }
        //Checks for input
        else if (Input.GetKey(KeyCode.S) || moveVertical < 0)
        {
            if (currentVAxis >= -rotateMaxVA)
            {
                currentVAxis = currentVAxis - constantChange;
                //Constant to change
                if (currentVAxis > 0) {/*Incase their instantly changing direction*/currentVAxis = currentVAxis + resistChange; }
            }
        }
        else
        {
            // Reset Rotation
            if (currentVAxis > memSpeedZ) { currentVAxis = currentVAxis - noKeyDrag; }
            else if (-currentVAxis > memSpeedZ) { currentVAxis = currentVAxis + noKeyDrag; }
            if (currentYxis != 0)
            {
                if (currentYxis >= memSpeedY) { currentYxis = currentYxis - noKeyDrag; }
                if (currentYxis <= memSpeedY) { currentYxis = currentYxis + noKeyDrag; }
            }
        }
    }

}
