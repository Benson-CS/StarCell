using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//At this point who knows who deserves the credit for this script between JetPackDan, Dnglchlk, or PhantomData87
// Jetpackdan did the shotgun stuff it was a bitch
public class pelletMove : MonoBehaviour
{
    //Defining variables for object
    private Rigidbody rb;
    public Control_Dominate sending;
    //Defining sent variables
    private int cloneAddingPew;
    //Defining variable
    private float ammo;
    private int shotGunShotsTotal;
    private int projectilesSpeed;
    private int projectilesMassiveSpeed;
    private int YaxisShotgunSpreadSeter;
    private int ZaxisShotgunSpreadSeter;
    //Variables to see if powerup is enabled
    private bool shotgunActive;
    private bool shieldActive;
    private bool mPActive;

    void Start()
    {
        //Defining variables
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        projectilesSpeed = sending.projectilesSpeed;
        projectilesMassiveSpeed = sending.projectilesMassiveSpeed;
        YaxisShotgunSpreadSeter = sending.YaxisShotgunSpreadSeter;
        ZaxisShotgunSpreadSeter = sending.ZaxisShotgunSpreadSeter;
        ammo = sending.ammo;
        cloneAddingPew = sending.cloneAddingPew;
        shotGunShotsTotal = sending.shotGunShotsTotal;
        shotgunActive = sending.shotgunActive;
        shieldActive = sending.shieldActive;
        mPActive = sending.mPActive;

        //Verifying if it's already active
        if (shotgunActive == true) { if (mPActive == false) { Invoke("shotgun", 0f); } }
        //Verifying if it's already active
        else if (mPActive == true) { Invoke("MP", 0f); }
        //Verifying if it's already active
        else { Invoke("a", 0f/*, 0.1f*/); }
    }

    void a()
    {
        //Verifying projectiles name
        for (var i = sending.cloneAddingPew + ammo; i > -ammo; i--)
        {
            //If true it gives movement to projectile in question
            if (gameObject.tag == "Pew" && gameObject.name == $"Pellet{i}")
            {
                rb = GameObject.Find($"Pellet{i}").GetComponent<Rigidbody>();
                rb.WakeUp();
                rb.AddForce(-projectilesSpeed, 0, 0, ForceMode.Impulse);
                Invoke("Undo",2f);
            }
            else { rb = GameObject.Find("Pellet").GetComponent<Rigidbody>(); }
            if (i < sending.cloneAddingPew - ammo) {/*Stops loop early if verification fails*/break; }
        }
    }
    void shotgun()//making the pellets have some spread when shot not summoning multiple
    {
        //If trye it gives movement to projectile in question
        for (int i = sending.cloneAddingPew + shotGunShotsTotal; i > -ammo; i--)
        {
            //Defines how each shotgun projectile of shotgun will act
            var YaxisShotgunSpread = Random.Range(YaxisShotgunSpreadSeter, -YaxisShotgunSpreadSeter);
            var ZaxisShotgunSpread = Random.Range(ZaxisShotgunSpreadSeter, -ZaxisShotgunSpreadSeter);
            if (gameObject.tag == "Shotgun" && gameObject.name == $"Pellet{i}")
            {
                //Added forced
                rb = GameObject.Find($"Pellet{i}").GetComponent<Rigidbody>();
                rb.AddForce(-projectilesSpeed, 0, 0, ForceMode.Impulse);
                rb.AddForce(0, ZaxisShotgunSpread, YaxisShotgunSpread, ForceMode.Impulse);
            }
            else { rb = GameObject.Find("Pellet").GetComponent<Rigidbody>(); }
            if (i < sending.cloneAddingPew - shotGunShotsTotal) {/*Stops loop early if verification failed*/break; }
        }
    }
    void MP()//For the big guy
    {
        //Verification of projectile in question
        for (var i = sending.cloneAddingPew + ammo; i > -ammo; i--)
        {
            //If true, sets movement of projectile
            if (gameObject.tag == "MP" && gameObject.name == $"Pellet{i}")
            {
                rb = GameObject.Find($"Pellet{i}").GetComponent<Rigidbody>();
                rb.AddForce(-projectilesMassiveSpeed, 0, 0, ForceMode.Impulse);
            }
            else { rb = GameObject.Find("Pellet").GetComponent<Rigidbody>(); }
            if (i < sending.cloneAddingPew - ammo) {/*Stops loop early if verification failed*/break; }
        }
    }
    void Undo()
    {
        rb.AddForce(projectilesSpeed, 0, 0, ForceMode.Impulse);
        rb.Sleep();
    }
}
