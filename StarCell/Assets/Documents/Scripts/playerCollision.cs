using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// original collision script(s) created by dnglchlk
// player explosion by JetPackDan
public class playerCollision : MonoBehaviour
{
    public bool debugBoom;
    private string ship = "ship3v8";
    public bool destroyEnable = true;
    private ParticleSystem particle;
    private int delaycounter = 10;
    //public GoToMenu GoToMenu;
    public bool debugMenu = false;

    private Control_Dominate sending;
    private bool didShipDie;
    void Awake()
    {
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
    }
    void OnCollisionEnter(Collision boom)

    {
        if (boom.gameObject.name == ship)
        {
            sending.didShipDie = true;
            GameObject.Find("DetachedScripts").GetComponent<timeScoreManager>().continueProcessing = false;

            if (destroyEnable == true)
            {
                // Explosion played at location of collision
                Explode(boom.transform);
                //Destroy objects in collision
                boom.gameObject.SetActive(false);
                gameObject.SetActive(false);
                //GameObject.Find("ShipAttachedCamera").GetComponent(FollowTarget).enabled = false;
                if (debugBoom == true) { Debug.Log("Boom!"); }
            }
            else { Debug.LogWarning("destroyEnable is not enabled within playerCollision"); }
        }
    }
    void Explode(Transform target)
    {
        // Getting particle explosion from object
        particle = GameObject.Find("ShipBoom").GetComponent<ParticleSystem>();
        // Set particle explosion's vector3 to transform of collision
        particle.transform.position = target.position;

        // Unnessecary as already logged at Line 32 -> Debug.Log("Explosion Instantiated");

        // Boom!
        particle.Play();
    }
    /*
    void MenusCreen()
    {
        if (delaycounter == 0)
        {
            if (debugMenu = true)
            {
                Debug.LogWarning("Loading Menu Screen...");
            }
            SceneManager.LoadScene("titleMenuTest");
        }
        --delaycounter;


    }
*/


}
