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
public class CubeWillSpinIDemand : MonoBehaviour
{
    private Quaternion myRotation = Quaternion.identity;
    private float a;
    public float spinSpeed;
    // Update is called once per frame
    void FixedUpdate()
    {
        var someValue = new Vector3(0f,-a,0f);
        a = a + spinSpeed;
        myRotation.eulerAngles = someValue;
        gameObject.transform.rotation = myRotation;
    }
}
