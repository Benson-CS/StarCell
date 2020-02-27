using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class tokenThings : MonoBehaviour
{
    //Defining
    private TextMeshProUGUI tokenCounter;
    private Control_Dominate sending;
    private GameObject ship;
    private GameObject token;
    //Variables
    private float followSpeed;
    void Awake()
    {
        //Defining
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        tokenCounter = GameObject.Find("CurrentTokenCount").GetComponent<TextMeshProUGUI>();
        tokenCounter.text = $"Tokens: {sending.currency}";
        
        if (sending.didShipDie == false)
        {
            ship = GameObject.Find("ship3v8");
        }
        followSpeed = sending.followSpeed;
        //Changes the collider's size
        gameObject.transform.localScale = new Vector3(sending.distanceOfTokenToPlayer, sending.distanceOfTokenToPlayer, sending.distanceOfTokenToPlayer);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "ship3v8")
        {
            ++sending.currency;
            tokenCounter.text = $"Tokens: {sending.currency}";
            Destroy(this.gameObject, 0f);

        }
    }
}
