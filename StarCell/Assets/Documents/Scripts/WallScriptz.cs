using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Created by:
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                        /
\|
*/
// Requires "GenScript"
public class WallScriptz : MonoBehaviour
{
    //Defining
    [Range(0, 200)] public int UpdateRate;
    public Vector3 positionInTime;
    private Transform positionCoords;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = UpdateRate;
        //Obtaining info from gameobject
        positionCoords = GameObject.Find("thenamesucked").GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate() { positionInTime = positionCoords.position; /*Save pos of object*/}
}
