using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tokenCollision : MonoBehaviour
{
    private Control_Dominate sending;
    // Start is called before the first frame update
    void Awake()
    {
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
    }

    void OnCollisionEnter(Collision boom)
    {
        if(boom.gameObject.name == "ship3v8")
        {
            ++sending.currency;
            Destroy(gameObject);
        }
    }
}
