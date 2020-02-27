using System;
using UnityEngine;


namespace UnityStandardAssets.Utility
{
    public class FollowTarget : MonoBehaviour
    {
        public Transform target;
        public Vector3 offset = new Vector3(0f, 7.5f, 0f);
        public bool elseDebug = false;
        private void LateUpdate()
        {
            if (GameObject.Find("ship3v8") == true)
            {
                transform.position = target.position + offset;
            }
            else
            {
                if (elseDebug == true)
                {
                    
                    Debug.Log("Ship died");
                }
            }
        }
    }
}
