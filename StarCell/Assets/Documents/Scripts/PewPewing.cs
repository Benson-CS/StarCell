using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
// Made by PhantomData87
// Jetpackdan did the shotgun stuff "it was a bitch"
// Formatting by dnglchlk because I care
// UnFormatting by PhantomData87 because I don't care

/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/
/*

       __   _______ .___________..______      ___       ______  __  ___  _______       ___      .__   __. 
      |  | |   ____||           ||   _  \    /   \     /      ||  |/  / |       \     /   \     |  \ |  | 
      |  | |  |__   `---|  |----`|  |_)  |  /  ^  \   |  ,----'|  '  /  |  .--.  |   /  ^  \    |   \|  | 
.--.  |  | |   __|      |  |     |   ___/  /  /_\  \  |  |     |    <   |  |  |  |  /  /_\  \   |  . `  | 
|  `--'  | |  |____     |  |     |  |     /  _____  \ |  `----.|  .  \  |  '--'  | /  _____  \  |  |\   | 
 \______/  |_______|    |__|     | _|    /__/     \__\ \______||__|\__\ |_______/ /__/     \__\ |__| \__| 
                                                                                                          
*/
public class PewPewing : MonoBehaviour
{
    //Debug
    public bool ammoDebug = false;
    public bool fireDebug = false;
    //Defining
    [HideInInspector]
    public Text a;
    private Control_Dominate sending;
    private Transform shipPosition;
    private Vector3 ProjectileAxis;
    private Quaternion ProjectileAxiss = Quaternion.identity;
    //Defining of Control_Dominate
    private string projectileKeyName;
    private Vector3 firstProjectileOffSet;
    private bool secondProjectileActive;
    private Vector3 secondProjectileOffSet;
    private float projectileDecay;
    private long ammo;
    private float regenOfProjectileRate;
    private float shootingSpeed;
    //Constant for memory
    private long memAmmo;
    private int ii;
    private int xii;
    //ship original cords
    private float shipPositionx;
    private float shipPositiony;
    private float shipPositionz;
    //1st pellet cords
    private float shipPositiondx;
    private float shipPositiondy;
    private float shipPositiondz;
    //2nd pellet cords
    private float shipPosition2dx;
    private float shipPosition2dy;
    private float shipPosition2dz;
    //the counter for the pellet move script
    private int cloneAddingPew;
    // private GameObject pelletsomething;
    public Transform pellet;
    private bool shotgunActive;
    private bool shieldActive;
    private bool mPActive;
    private bool buttonNeededS;
    private bool buttonNeededSh;
    private bool buttonNeededMP;
    private int shotGunShotsTotal;
    private float shotgunprojectileDecay;
    private float massiveOffSet;
    private float massiveProjectileSize;
    //Timer
    private float shotgunStopDelay;
    private float shieldStopDelay;
    private float mPStopDelay;
    //Pooler
    helperPooler helperPooler;

    void Awake()
    {
        //Object Pooler
        helperPooler = helperPooler.Instance;
        //Defining
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        a = GameObject.Find("AmmoCounter").GetComponent<Text>();
        projectileKeyName = sending.projectileKeyName;
        firstProjectileOffSet = sending.firstProjectileOffSet;
        secondProjectileActive = sending.secondProjectileActive;
        secondProjectileOffSet = sending.secondProjectileOffSet;
        projectileDecay = sending.projectileDecay;
        ammo = sending.ammo;
        shotgunStopDelay = sending.shotgunStopDelay;
        shieldStopDelay = sending.shieldStopDelay;
        mPStopDelay = sending.mPStopDelay;
        shotgunStopDelay = sending.shotgunStopDelay;
        shieldStopDelay = sending.shieldStopDelay;
        mPStopDelay = sending.mPStopDelay;
        regenOfProjectileRate = sending.regenOfProjectileRate;
        massiveOffSet = sending.massiveOffset;
        ProjectileAxis = sending.ProjectileAxis;
        shootingSpeed = sending.shootingSpeed;
        shotgunprojectileDecay = sending.shotgunprojectileDecay;
        shotgunActive = sending.shotgunActive;
        shotGunShotsTotal = sending.shotGunShotsTotal;
        buttonNeededS = sending.buttonNeededS;
        buttonNeededSh = sending.buttonNeededSh;
        buttonNeededMP = sending.buttonNeededMP;
        massiveProjectileSize = sending.massiveProjectileSize;

    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        ProjectileAxiss.eulerAngles = ProjectileAxis;
        //Saving max ammo value
        memAmmo = ammo;
        a.text = "" + memAmmo + "";
        //Saving offset value for firts projectile
        shipPositiondx = firstProjectileOffSet.x;
        shipPositiondy = firstProjectileOffSet.y;
        shipPositiondz = firstProjectileOffSet.z;
        //Saving offset value for second projectile
        shipPosition2dx = secondProjectileOffSet.x;
        shipPosition2dy = secondProjectileOffSet.y;
        shipPosition2dz = secondProjectileOffSet.z;
        //Starting timers
        InvokeRepeating("ProjectileRegenn", 0f, regenOfProjectileRate);
        InvokeRepeating("Shootingg", 0f, shootingSpeed);
        shipPosition = GameObject.Find("ship3v8").GetComponent<Transform>();
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Update()
    {
        //Verification and updating purposes
        a.text = "" + ammo + "";
        shotgunActive = sending.shotgunActive;
        shieldActive = sending.shieldActive;
        mPActive = sending.mPActive;
        sending.currentAmmo = ammo;
    }
    /// <summary>
    /// Update is called once per frame
    /// </summary>

    void ProjectileRegenn()
    {
        //This adds more ammo
        if (ammo < memAmmo)
        {
            //Debug
            if (ammoDebug == true) { Debug.Log("+1 ammo"); }
            //Adds ammo
            ammo = ammo + 1;
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void Shootingg()
    {
        //Redefining ships position
        shipPositionx = shipPosition.position.x;
        shipPositiony = shipPosition.position.y;
        shipPositionz = shipPosition.position.z;
        //Checks if shield is active
        if (shieldActive == true)
        {
            //Checks if shield needs button to be press
            if (buttonNeededSh == false)
            {
                //Makes sure that it's activated more than once 
                if (ii < 0)
                {
                    //Another activation thing to remove shield powerup
                    if (xii <= 0) { Invoke("DelayShield", shieldStopDelay); }
                    //Cancels loop of "shield"
                    CancelInvoke("shield");
                    //Invokes "shield"
                    InvokeRepeating("shield", 0f, 1f);
                }
            }
        }
        //Makes sure if player pressed key
        if (Input.GetKey(sending.projectileKeyName.ToLower())) //Need to get custom keycode
        {
            //Debug
            if (fireDebug == true) { Debug.Log("Laser Fired!"); }
            if (ammo <= memAmmo && ammo > 0)
            {
                //Debug
                if (ammoDebug == true) { Debug.Log("-1 ammo"); }
                //Removes ammo
                --ammo;
                //Verifies if shotgun is active
                if (shotgunActive == true)
                {
                    //Checks if it needs a key
                    if (buttonNeededS == false)
                    {
                        //Makes sure only one instance is ran
                        if (xii <= 0) {/*Invokes "DelayShotgun" to remove powerup*/Invoke("DelayShotgun", shotgunStopDelay); }
                        //Allows shotgun to function
                        Invoke("shotgun", 0f);
                    }
                }
                //Verifies if mp is active
                else if (mPActive == true)
                {
                    //Verifies if it needs button
                    if (buttonNeededMP == false)
                    {
                        //Makes sure only one instance is ran
                        if (xii <= 0) {/*Invokes "DelayMP" to remove powerup*/Invoke("DelayMP", mPStopDelay); }
                        //Allows mp to function
                        Invoke("mp", 0f);
                    }
                }
                else {/*Allows regular shooting*/Invoke("normalShoot", 0f); }

            }
            //Changes ammo text in GUI
            a.text = "" + ammo + "";
        }
        //Verifies if pressing a button is needed for shooting shotgun ammo
        if (Input.GetKey(sending.projectileKeyNameShot.ToLower()))
        {
            //Also checks if shotgun is active
            if (shotgunActive == true)
            {
                //Checks if button is needed
                if (buttonNeededS == true)
                {
                    //Makes sure it only one instance is ran
                    if (xii <= 0) { Invoke("DelayShotgun", shotgunStopDelay); }
                    //Allows shotgun to function
                    Invoke("shotgun", 0f);
                }
            }
        }
        //Checks if shield's key works
        if (Input.GetKey(sending.projectileKeyNameShield.ToLower()))
        {
            //Checks if shield is active
            if (shieldActive == true)
            {
                if (buttonNeededSh == true)
                {
                    //Makes sure that shield is ran once
                    if (ii < 0)
                    {
                        //Makes sure only one isntance is ran
                        if (xii <= 0) {/*Invokes "DelayShield" to rmeove powerup*/Invoke("DelayShield", shieldStopDelay); }
                        //Stops active shield loop
                        CancelInvoke("shield");
                        //Invokes a repeating shield loop
                        InvokeRepeating("shield", 0f, 1f);
                    }
                }
            }
        }
        //Verifies if mp's key is pressed
        if (Input.GetKey(sending.projectileKeyNameMp.ToLower()))
        {
            //Checks if mp is active
            if (mPActive == true)
            {
                //Verifies if powerup is active
                if (buttonNeededMP == true)
                {
                    //Makes sure only one isntance is ran
                    if (xii <= 0) {/*Invokes "DelayMP" to stop powerup*/Invoke("DelayMP", mPStopDelay); }
                    //Allows mp to function
                    Invoke("mp", 0f);
                }
            }
        }
    }
    //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void normalShoot()
    {
        //Gets ships position in time + offset
        Vector3 position1 = new Vector3(shipPositionx + shipPositiondx, shipPositiony + shipPositiondy, shipPositionz + shipPositiondz);
        //Checks if second projectile is active
        if (secondProjectileActive == true)
        {
            //For projectile name
            sending.cloneAddingPew = cloneAddingPew + 1;
            ++cloneAddingPew;
            //Defines possible second position of 2nd projectile
            Vector3 position2 = new Vector3(shipPositionx + shipPosition2dx, shipPositiony + shipPosition2dy, shipPositionz + shipPosition2dz);
            //Spawns second projectile
            var c = helperPooler.Instance.SpawnFromPool("Pew", position2, ProjectileAxiss, projectileDecay, 10);
            c.tag = "Pew";
            c.name = $"Pellet{sending.cloneAddingPew}";
            sending.cloneAddingPew = cloneAddingPew + 1;
            //Updates globally what is the current projectile #
            cloneAddingPew = sending.cloneAddingPew;
        }
        //For projectile name
        sending.cloneAddingPew = cloneAddingPew + 1;
        ++cloneAddingPew;
        //Spawns first projectile
        var b = helperPooler.Instance.SpawnFromPool("Pew", position1, ProjectileAxiss, projectileDecay, 10);
        b.tag = "Pew";
        b.name = $"Pellet{sending.cloneAddingPew}"; //
        //Updates globally what is the current projectile #
        cloneAddingPew = sending.cloneAddingPew;
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void shotgun()
    {
        //Verification
        ++xii;
        //Spawns all possible shotguns
        for (int k = 0; k < shotGunShotsTotal; k++)
        {
            //float random1 = (Random.Range(-100, 100));
            //float random2 = Random.Range(-100, 100)/100;

            //Defines spread of projectiles of shotgun
            float random3 = Random.Range(-100, 100);
            random3 = random3 / 1000;
            float random4 = Random.Range(-100, 100);
            random4 = random4 / 1000;
            float random5 = Random.Range(-100, 100);
            random5 = random5 / 1000;
            float random6 = Random.Range(-100, 100);
            random6 = random6 / 1000;

            //Defines positions of both projectile
            Vector3 position1 = new Vector3(shipPositionx + shipPositiondx, shipPositiony + shipPositiondy + random3, shipPositionz + shipPositiondz + random5);
            Vector3 position2 = new Vector3(shipPositionx + shipPosition2dx, shipPositiony + shipPosition2dy + random4, shipPositionz + shipPosition2dz + random6);
            //Verifies if second projectile is active
            if (secondProjectileActive == true)
            {
                //Defines projectile namme
                sending.cloneAddingPew = cloneAddingPew + 1;
                ++cloneAddingPew;
                //Spawns second projectile
                var d = Instantiate(pellet, position2, ProjectileAxiss);
                d.tag = "Shotgun";
                d.name = $"Pellet{sending.cloneAddingPew}";
                sending.cloneAddingPew = cloneAddingPew + 1;
                Destroy(d.gameObject, shotgunprojectileDecay);
                //Updates globally what is the current projectile #
                cloneAddingPew = sending.cloneAddingPew;
            }
            //Defines projectile name
            sending.cloneAddingPew = cloneAddingPew + 1;
            ++cloneAddingPew;
            //Spawns first projectile
            var e = Instantiate(pellet, position1, ProjectileAxiss).gameObject;
            e.tag = "Shotgun";
            e.name = $"Pellet{sending.cloneAddingPew}";
            Destroy(e.gameObject, shotgunprojectileDecay);
            //Updates globally what is the current projectile #
            cloneAddingPew = sending.cloneAddingPew;
        }
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void shield()
    {
        //Verification
        ++xii;
        //Debug
        Debug.Log("Not off!");
        //Something comes here
    }
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void mp()
    {
        //Verification
        ++xii;
        //Defines position of ship + projectile offset
        shipPositiondx = shipPositiondx + massiveOffSet;
        //Defines position of projectile
        Vector3 position1 = new Vector3(shipPositionx + shipPositiondx, shipPositiony + shipPositiondy, shipPositionz + shipPositiondz);  //ship positsopn
        //Verifies if second projectile is active
        if (secondProjectileActive == true)
        {
            //Defines projectile name
            sending.cloneAddingPew = cloneAddingPew + 1;
            ++cloneAddingPew;
            //Defines second projectile position
            Vector3 position2 = new Vector3(shipPositionx + shipPosition2dx, shipPositiony + shipPosition2dy, shipPositionz + shipPosition2dz);
            //Spawns second projectile
            var g = Instantiate(pellet, position2, ProjectileAxiss);
            g.localScale = g.localScale * massiveProjectileSize;
            g.tag = "MP";
            g.name = $"Pellet{sending.cloneAddingPew}";
            sending.cloneAddingPew = cloneAddingPew + 1;
            Destroy(g.gameObject, projectileDecay);
            //Updates globally what is the current projectile #
            cloneAddingPew = sending.cloneAddingPew;
        }
        sending.cloneAddingPew = cloneAddingPew + 1;
        ++cloneAddingPew;
        //Spawns first projectile
        var f = Instantiate(pellet, position1, ProjectileAxiss).gameObject;
        f.tag = "MP";
        f.name = $"Pellet{sending.cloneAddingPew}";
        f.transform.localScale = f.transform.localScale * massiveProjectileSize;
        Destroy(f.gameObject, projectileDecay);
        //Updates globally what is the current projectile #
        cloneAddingPew = sending.cloneAddingPew;
    }

    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    void DelayShotgun()
    {
        //Deactivates powerup
        sending.shotgunActive = false;
        //Verification
        xii = 0;
    }
    void DelayShield()
    {
        //Deactivates powerup
        sending.shieldActive = false;
        //Verification
        xii = 0;
    }
    void DelayMP()
    {
        //Deactivates powerup
        sending.mPActive = false;
        //Verification
        xii = 0;
        //Changes ship's position to original
        shipPositiondx = firstProjectileOffSet.x;
        //Cancels other 'mp' loops
        CancelInvoke("mp");
    }
}
