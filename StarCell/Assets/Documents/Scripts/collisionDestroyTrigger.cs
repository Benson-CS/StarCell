using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Made and formatted properly by dnglchlk
// Other components added by JetPackDan and
// Complicated by PhantomDat87
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                        /
\|
*/
public class collisionDestroyTrigger : MonoBehaviour
{
    //Memory non-static variables
    public bool debug = false;
    //Defining
    private string gameObjectTag = "Pew";
    private string gameObjectTag2 = "Shotgun";
    private string gameObjectTag3 = "Shield";
    private string gameObjectTag4 = "MP";
    private Control_Dominate sending;
    private Transform currentAsteroid;
    private ParticleSystem test;
    private float scaleOfAsteroid;
    //By Control_Dominate
    private float jrSmallBoi;
    private float jrBigBoi;
    private int jrSpeed;
    private int minThrustJr;
    private int maxThrustJr;
    private int spawnAmount;
    private int minSpawnRange;
    private int newAsteroidDecay;
    private float asteroidSizeToSpawnMore;
    private float ammo;
    private Vector3 newAsteroidOffset;
    private Quaternion rotationOfTokenn = Quaternion.identity;
    private int tokenSize;
    //Verification
    private Collision coll;
    private int cloneAddingPew;
    private bool isIt;
    //To stop script
    private bool didShipDie;

    void Awake()
    {
        //Defining variables
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        currentAsteroid = this.gameObject.GetComponent<Transform>();
        jrSmallBoi = sending.jrSmallBoi;
        jrBigBoi = sending.jrBigBoi;
        jrSpeed = sending.jrSpeed;
        didShipDie = sending.didShipDie;
        minThrustJr = sending.minThrustJr;
        maxThrustJr = sending.maxThrustJr;
        spawnAmount = sending.spawnAmount;
        minSpawnRange = sending.minSpawnRange;
        newAsteroidDecay = sending.newAsteroidDecay;
        asteroidSizeToSpawnMore = sending.asteroidSizeToSpawnMore;
        ammo = sending.ammo;
        tokenSize = sending.tokenSize;
        rotationOfTokenn = sending.rotationOfToken;
        newAsteroidOffset = sending.newAsteroidOffset;
    }

    //Used to detect Collision
    void OnCollisionEnter(Collision col)
    {
        //Basic variables being set up
        coll = col;
        var a = currentAsteroid.localScale;
        scaleOfAsteroid = a.x;
        cloneAddingPew = sending.cloneAddingPew;
        didShipDie = sending.didShipDie;
        if (didShipDie == false)
        {
        GameObject.Find("DetachedScripts").GetComponent<timeScoreManager>().Invoke("asteroidhit", 0f);
        }
        //This loop will verify the projectile that was collided with asteroid
        for (int i = sending.cloneAddingPew; i > -ammo; i--)
        {
            if (col.gameObject.name == $"Pellet{i}")
            {
                //Onced passed, it will check tag to determine powerup
                if (col.gameObject.tag == gameObjectTag)
                {
                    //Destroys object it is attached to (asteroid)
                    if (scaleOfAsteroid >= asteroidSizeToSpawnMore)
                    {
                        //Makes animation
                        Explode(col.transform);
                        //Causes smaller asteroids to spawn
                        Invoke("SpawningMore", 0f);
                        //Spawns a token
                        Invoke("currency", 0f);
                        //Destroys pellet
                        Invoke("leaveOurMindsAlone",0f);
                        //Destroys the asteroid
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        //Makes animation
                        Explode(col.transform);
                        //Spawns a token
                        Invoke("currency", 0f);
                        //Destroys pellet
                        Invoke("leaveOurMindsAlone",0f);
                        //Destroys the asteroid
                        gameObject.SetActive(false);
                    }
                    break;
                }
                else if (col.gameObject.tag == gameObjectTag2)
                {
                    //Destroys object it is attached to (asteroid)
                    if (scaleOfAsteroid >= asteroidSizeToSpawnMore)
                    {
                        //Makes animation
                        Explode(col.transform);
                        //Causes smaller asteroids to spawn
                        Invoke("SpawningMore", 0f);
                        //Spawns a token
                        Invoke("currency", 0f);
                        //Destroys pellet
                        Invoke("leaveOurMindsAlone",0f);
                        //Destroys the asteroid
                        gameObject.SetActive(false);
                    }
                    else
                    {
                        //Makes animation
                        Explode(col.transform);
                        //Spawns a token
                        Invoke("currency", 0f);
                        //Destroys pellet
                        Invoke("leaveOurMindsAlone",0f);
                        //Destroys the asteroid
                        gameObject.SetActive(false);

                    }
                }
                else if (col.gameObject.tag == gameObjectTag3)
                {
                  //Makes animation
                  Explode(col.transform);
                  //Spawns a token
                  Invoke("currency", 0f);
                  //Destroys the asteroid
                  gameObject.SetActive(false);
                }
                else if (col.gameObject.tag == gameObjectTag4)
                {
                    //Makes animation
                    Explode(col.transform);
                    //Spawns a token
                    Invoke("currency", 0f);
                    //Destroys the asteroid
                    gameObject.SetActive(false);
                }
            }
        }
        void Explode(Transform target)
        {
            //Plays animation/sets up variables
            test = GameObject.Find("RockExplosion").GetComponent<ParticleSystem>();
            test.transform.position = target.position;
            test.Play(); //playing the animation
        }
    }
    void FixedUpdateOnApplicationQuit()
    {
        didShipDie = sending.didShipDie;
        if (didShipDie == true)
        {
            gameObject.SetActive(false);
        }
    }
    void SpawningMore()
    {
        //Defining variables
        var a = currentAsteroid.localScale;
        var asteroidPosition = gameObject.transform.position;
        //This will spawn the amount of asteroids inside the current asteroid based on the given number
        for (int k = 0; k < spawnAmount; k++)
        {
            //These if statements simulate the placements so it's not predictable where new asteroids spawn
            if (k % 2 == 0 && isIt == true)
            {
                //Defines position
                Vector3 position = new Vector3(Random.Range(-newAsteroidOffset.x + asteroidPosition.x + Random.Range(-minSpawnRange, -a.x), newAsteroidOffset.x + asteroidPosition.x + Random.Range(-minSpawnRange, -a.x)), Random.Range(-newAsteroidOffset.y + asteroidPosition.y + Random.Range(-minSpawnRange, -a.y), newAsteroidOffset.y + asteroidPosition.y + Random.Range(-minSpawnRange, -a.y)), Random.Range(-newAsteroidOffset.z + asteroidPosition.z + Random.Range(-minSpawnRange, -a.z), newAsteroidOffset.z + asteroidPosition.z + Random.Range(-minSpawnRange, -a.z)));
                //Clones the object
                var temp = helperPooler.Instance.SpawnFromPool($"Asteroid {Random.Range(1,20)}", position, Random.rotation, newAsteroidDecay, 1);
                if (debug == true)
                {
                    Debug.Log(temp);
                }
                //Sets new size of asteroid
                temp.transform.localScale = new Vector3(1,1,1);
                temp.transform.localScale = new Vector3(Random.Range(jrSmallBoi, jrBigBoi), Random.Range(jrSmallBoi, jrBigBoi), Random.Range(jrSmallBoi, jrBigBoi));
                //Adds movement to asteroid
                var zy = temp.GetComponent<Rigidbody>();
                var yx = Random.Range(minThrustJr, maxThrustJr);
                var xy = Random.Range(minThrustJr, maxThrustJr);
                //Lets asteroids move
                zy.isKinematic = false;
                zy.AddForce(-jrSpeed,0,0,ForceMode.Impulse);
                zy.AddForce(0, yx, xy,ForceMode.Impulse);
                temp.GetComponent<addRandomMovement>().enabled = true;
                temp.GetComponent<collisionDestroyTrigger>().enabled = true;
                //Used to similate unpredictableness
                isIt = false;
            }
            else
            {
                //Defines position
                Vector3 position = new Vector3(Random.Range(-newAsteroidOffset.x + asteroidPosition.x + Random.Range(minSpawnRange, a.x), newAsteroidOffset.x + asteroidPosition.x + Random.Range(minSpawnRange, a.x)), Random.Range(-newAsteroidOffset.y + asteroidPosition.y + Random.Range(minSpawnRange, a.y), newAsteroidOffset.y + asteroidPosition.y + Random.Range(minSpawnRange, a.y)), Random.Range(-newAsteroidOffset.z + asteroidPosition.z + Random.Range(minSpawnRange, a.z), newAsteroidOffset.z + asteroidPosition.z + Random.Range(minSpawnRange, a.z)));
                var temp = helperPooler.Instance.SpawnFromPool($"Asteroid {Random.Range(1,20)}", position, Random.rotation, newAsteroidDecay, 1);
                //Sets new size of asteroid
                temp.transform.localScale = new Vector3(Random.Range(jrSmallBoi, jrBigBoi), Random.Range(jrSmallBoi, jrBigBoi), Random.Range(jrSmallBoi, jrBigBoi));
                //Adds movement to asteroid
                var zy = temp.GetComponent<Rigidbody>();
                var yx = Random.Range(minThrustJr, maxThrustJr);
                var xy = Random.Range(minThrustJr, maxThrustJr);
                //Lets asteroids move
                zy.isKinematic = false;
                zy.AddForce(-jrSpeed, 0, 0, ForceMode.Impulse);
                zy.AddForce(0, yx, xy, ForceMode.Impulse);
                temp.GetComponent<addRandomMovement>().enabled = true;
                temp.GetComponent<collisionDestroyTrigger>().enabled = true;
                //Used to similate unpredictableness
                isIt = true;
            }
        }
    }
    void currency()
    {
        //Grabs asteroid's position
        var asteroidPosition = gameObject.transform.position;
        //Finds token
        var objectToken = GameObject.Find("Token");
        //Saves a positon for token
        Vector3 position = new Vector3(asteroidPosition.x, asteroidPosition.y, asteroidPosition.z);
        //Spawns token
        var temp = helperPooler.Instance.SpawnFromPool("Token", position, rotationOfTokenn, newAsteroidDecay, 100);
        //Naming of token
        ++sending.tokenCount;
        temp.name = $"Token{sending.tokenCount}";
        //Tag of token
        temp.tag = "Token";
        //How big token is
        temp.transform.localScale = new Vector3(1,1,1);
        temp.transform.localScale = new Vector3(tokenSize, tokenSize, tokenSize);
    }
    void leaveOurMindsAlone()
    {
        var removingPellet = coll.gameObject;
        removingPellet.SetActive(false);
    }
}
