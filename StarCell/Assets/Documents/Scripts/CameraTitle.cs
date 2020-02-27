using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Assisted by PhantomData87
public class CameraTitle : MonoBehaviour
{
  //Sets up basic operators
    public float xSpread;
    public float zSpread;
    public float yOffset;
    public Transform centerPoint;
    public float rotSpeed;
    public bool rotateClockwise;
    //some variable
    float timer = 0;

    // Update is called once per frame
    public void Update()
    {
      timer += Time.deltaTime * rotSpeed;
      Rotate();
      transform.LookAt(centerPoint);
    }
    void Rotate()
    {
      //checks if 'rotateClockwise' is true or false
      if(rotateClockwise)
      {
        //Uses unit circle to place the camera. Inside of the circle
        float x = -Mathf.Cos(timer) * xSpread;
        float z = Mathf.Sin(timer) * zSpread;
        Vector3 pos = new Vector3(x , yOffset , z);
        //changes position
        transform.position = pos + centerPoint.position;
      }
      else
      {
        float x = Mathf.Cos(timer) * xSpread;
        float z = Mathf.Sin(timer) * zSpread;
        Vector3 pos = new Vector3(x , yOffset, z);
        transform.position = pos + centerPoint.position;
      }
    }
}
