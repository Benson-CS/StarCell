using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

//Polished a lot by PhantomData87
// color changing done by jetpackdan
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/

public class GenScript : MonoBehaviour
{
    //Asteroid verification
    private int currentAsteroid;
    //Basic defining
    private Control_Dominate sending;
    public bool fieldDebug = false;
    //Gameobject defining
    private float smallBoi;
    private float bigBoi;
    private bool didShipDie;
    private float centerPointX;
    private float centerPointY;
    private float centerPointZ;
    private WallScriptz float_coords;
    private float asteroidDepth;
    private GameObject[] asteroidList;
    private GameObject[] powerupList;
    private float destroyDelay;
    private int asteroidCount;
    //Shotgun
    private int shotgunSpawnTimer;
    private int shotgunMaxAmount;
    private int shotgunMinAmount;
    private int oneInAShotguns;
    private bool delayPowerupShotgun;
    //Shield
    private int shieldMaxAmount;
    private int shieldMinAmount;
    private int shieldSpawnTimer;
    private int oneInAShield;
    private bool delayPowerupShield;
    //MP
    private int mPMaxAmount;
    private int mPMinAmount;
    private int mPSpawnTimer;
    private int oneInAMP;
    private bool delayPowerupMP;
    //Level
    private float difficulty;
    private float difficultyRate;
    private float delayForDifficultyRate;
    private float asteroidHealth;
    private float asteroidHealthRate;
    private int levelTotal;
    private float levelCompletionTime;
    private float levelWaitTime;
    private bool levelOn;
    private int betterPowerupStartLevel;
    private int enemyStartLevel;
    private int structureSpawnRate;
    private int rareStructureSpawnRate;
    private int enemySpawnRate;
    private float powerupSpawnRange;
    //Boss
    private float delayForBoss;
    //Tutorial
    private bool skipTutorial;
    private int currentTutorialStage;
    private float delayTutorial;
    //Verification
    private int asdfghjkl;
    //Other
    private Quaternion rotationOfPowerups = Quaternion.identity;
    private float rangeAsteroid;
    private float spanwTime;
    private Transform chosenAsteroid;
    //Pooler
    helperPooler helperPooler;
    //asteroid color
    private int AsteroidRed;
    private int AsteroidGreen;
    private int AsteroidBlue;
    private int asteroidColorSelector;


    void Awake()
    {
        //Object Pooler
        helperPooler = helperPooler.Instance;
        //Control_Dominate script stuff
        sending = GameObject.Find("Control panel").GetComponent<Control_Dominate>();
        asteroidDepth = sending.asteroidDepth;
        destroyDelay = sending.destroyDelay;
        asteroidCount = sending.asteroidCount;
        rangeAsteroid = sending.rangeAsteroid;
        spanwTime = sending.spanwTime;
        smallBoi = sending.smallBoi;
        bigBoi = sending.bigBoi;
        rotationOfPowerups = sending.rotationOfPowerups;
        currentAsteroid = sending.currentAsteroid;
        //Shotgun
        shotgunSpawnTimer = sending.shotgunSpawnTimer;
        shotgunMaxAmount = sending.shotgunMaxAmount;
        shotgunMinAmount = sending.shotgunMinAmount;
        oneInAShotguns = sending.oneInAShotguns;
        delayPowerupShotgun = sending.delayPowerupShotgun;
        //Shield
        shieldMaxAmount = sending.shieldMaxAmount;
        shieldMinAmount = sending.shieldMinAmount;
        shieldSpawnTimer = sending.shieldSpawnTimer;
        oneInAShield = sending.oneInAShield;
        delayPowerupShield = sending.delayPowerupShield;
        //Massive Projectile
        mPMaxAmount = sending.mPMaxAmount;
        mPSpawnTimer = sending.mPSpawnTimer;
        oneInAMP = sending.oneInAMP;
        delayPowerupMP = sending.delayPowerupMP;
        //Level
        powerupSpawnRange = sending.powerupSpawnRange;
        difficulty = sending.difficulty;
        difficultyRate = sending.difficultyRate;
        delayForDifficultyRate = sending.delayForDifficultyRate;
        asteroidHealth = sending.asteroidHealth;
        asteroidHealthRate = sending.asteroidHealth;
        levelTotal = sending.levelTotal;
        levelCompletionTime = sending.levelCompletionTime;
        levelWaitTime = sending.levelWaitTime;
        betterPowerupStartLevel = sending.betterPowerupStartLevel;
        enemyStartLevel = sending.enemyStartLevel;
        structureSpawnRate = sending.structureSpawnRate;
        rareStructureSpawnRate = sending.rareStructureSpawnRate;
        enemySpawnRate = sending.enemySpawnRate;
        //Tutorial
        delayTutorial = sending.delayTutorial;
        skipTutorial = sending.skipTutorial;
        //Boss
        delayForBoss = sending.delayForBoss;
        //Difficulty impact
        if (difficulty >= 3) { asteroidCount = asteroidCount * 2; } else if (difficulty >= 2) { asteroidCount = asteroidCount; } else { asteroidCount = asteroidCount / 2; }
        if (skipTutorial == true) { sending.currentLevel = 1; }
    }

    // Start is called before the first frame update
    private void Start()
    {
        //Defining variables on what is our object as a reference
        InvokeRepeating("GenScriptz", 1.0f, spanwTime);

        InvokeRepeating("Shotgun", 5f, shotgunSpawnTimer);

        InvokeRepeating("Shield", 5f, shieldSpawnTimer);

        InvokeRepeating("MP", 5f, mPSpawnTimer);

        if (sending.currentLevel == 1)
        {
            Invoke("Wait", 0f);
        }

        float_coords = GameObject.Find("thenamesucked").GetComponent<WallScriptz>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        didShipDie = sending.didShipDie;
        //Getting position of our wall object initiator
        centerPointX = float_coords.positionInTime.x;
        centerPointY = float_coords.positionInTime.y;
        centerPointZ = float_coords.positionInTime.z;
    }
    void GenScriptz()
    {
        //Ignore
        var abc = 1;
        //Checks if game has ended
        if (didShipDie == false && levelOn == true)
        {
            if (sending.currentLevel == 0)
            {
                levelOn = false;
                InvokeRepeating("Tutorial", 3f, delayTutorial);
            }
            //If currentLevel is at the higest possible value, it starts a final level
            else if (sending.currentLevel == levelTotal)
            {
                Invoke("Boss", delayForBoss);
                //levelOn = false;
            }
            //Lets the more overpowered level stuff appear
            else if (betterPowerupStartLevel == sending.currentLevel && asdfghjkl == 0)
            {
                //Verification to prevent this if statement to forever repeat
                asdfghjkl = 1;
                //To enable certain powerups back on, and I mean all of them
                delayPowerupMP = false;
                delayPowerupShield = false;
                delayPowerupShotgun = false;
            }
            //Basic spawning
            else if (levelTotal >= sending.currentLevel)
            {
                //Checks if debug is on
                if (fieldDebug == true)
                {
                    Debug.Log("Making field");
                }
                //Making asteroids spawn
                for (int loop = 0; loop < asteroidCount; loop++)
                {
                    asteroidColorSelector = Random.Range(1, 8);

                    if (asteroidColorSelector == 1)//redish iron asteroid
                    {
                        AsteroidRed =(Random.Range(100, 250))/100;
                        int randomNUmberHolderForColor = 1; //making the astroid diffrent shades of red 
                        AsteroidGreen = randomNUmberHolderForColor;//set to a fixed value 
                        AsteroidBlue = randomNUmberHolderForColor;//set to a fixed value 
                       // Debug.Log("red");
                    }
                    else if (asteroidColorSelector == 2 | asteroidColorSelector == 3 | asteroidColorSelector == 4 | asteroidColorSelector == 5) //grey colod asteroid
                    {
                        int randomNUmberHolderForColor = (Random.Range(100,500 ))/100; //picking random values for the colors of gray 
                        AsteroidRed = randomNUmberHolderForColor;   
                        AsteroidGreen = randomNUmberHolderForColor;
                        AsteroidBlue = randomNUmberHolderForColor;
                       // Debug.Log("gray");
                    }
                    else if (asteroidColorSelector == 6 | asteroidColorSelector == 7 | asteroidColorSelector == 8) //blueish asteroid color
                    {
                        int randomNUmberHolderForColor = 1;
                        AsteroidRed = randomNUmberHolderForColor;//set to a fixed value 
                        AsteroidGreen = randomNUmberHolderForColor;//set to a fixed value 
                        AsteroidBlue = (Random.Range(100,250))/100;//making geh asteroiud a more blue color 
                       // Debug.Log("Blue");
                    }
                    //Setting position of asteroids
                    Vector3 position = new Vector3(Random.Range(-asteroidDepth + centerPointX, asteroidDepth + centerPointX), Random.Range(-rangeAsteroid + centerPointY, rangeAsteroid + centerPointY), Random.Range(-rangeAsteroid + centerPointZ, rangeAsteroid + centerPointZ));
                    //Spawning asteroid from a list, and modifying it directly
                    var temp = helperPooler.Instance.SpawnFromPool($"Asteroid {Random.Range(1, 20)}", position, rotationOfPowerups, destroyDelay, 1000);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    temp.GetComponent<Renderer>().material.color = new Color(AsteroidRed, AsteroidGreen, AsteroidBlue); //sets the colors for the asteroid 
                    temp.transform.localScale = temp.transform.localScale * Random.Range(smallBoi, bigBoi);
                    if (currentAsteroid > 10000000000)
                    {
                        sending.currentAsteroid = 0;
                        currentAsteroid = 0;
                    }
                    else
                    {
                        sending.currentAsteroid = currentAsteroid + 1;
                        ++currentAsteroid;
                    }
                    temp.name = $"asteroid{currentAsteroid}";
                }
            }
            else
            {
                //Checks if debug is on
                if (fieldDebug == true)
                {
                    Debug.Log("Making field");
                }
                //Making asteroids spawn
                for (int loop = 0; loop < asteroidCount; loop++)
                {
                    asteroidColorSelector = Random.Range(1, 8);

                    if (asteroidColorSelector == 1)//redish iron asteroid
                    {
                        AsteroidRed = Random.Range(5, 10);
                        int randomNUmberHolderForColor = 5; //making the astroid diffrent shades of red 
                        AsteroidGreen = randomNUmberHolderForColor;//set to a fixed value 
                        AsteroidBlue = randomNUmberHolderForColor;//set to a fixed value 
                        //Debug.Log("red");
                    }
                    else if (asteroidColorSelector == 2 | asteroidColorSelector == 3 | asteroidColorSelector == 4 | asteroidColorSelector == 5) //grey colod asteroid
                    {
                        int randomNUmberHolderForColor = Random.Range(1, 10); //picking random values for the colors of gray 
                        AsteroidRed = randomNUmberHolderForColor;   
                        AsteroidGreen = randomNUmberHolderForColor;
                        AsteroidBlue = randomNUmberHolderForColor;
                       // Debug.Log("gray");
                    }
                    else if (asteroidColorSelector == 6 | asteroidColorSelector == 7 | asteroidColorSelector == 8) //blueish asteroid color
                    {
                        int randomNUmberHolderForColor = 5;
                        AsteroidRed = randomNUmberHolderForColor;//set to a fixed value 
                        AsteroidGreen = randomNUmberHolderForColor;//set to a fixed value 
                        AsteroidBlue = Random.Range(5, 10);//making geh asteroiud a more blue color 
                       // Debug.Log("Blue");
                    }
                    //Setting position of asteroids
                    Vector3 position = new Vector3(Random.Range(-asteroidDepth + centerPointX, asteroidDepth + centerPointX), Random.Range(-rangeAsteroid + centerPointY, rangeAsteroid + centerPointY), Random.Range(-rangeAsteroid + centerPointZ, rangeAsteroid + centerPointZ));
                    //Spawning asteroid from a list, and modifying it directly
                    var temp = helperPooler.Instance.SpawnFromPool($"Asteroid {Random.Range(1, 20)}", position, rotationOfPowerups, destroyDelay, 1000);
                    temp.transform.localScale = new Vector3(1, 1, 1);
                    temp.GetComponent<Renderer>().material.color = new Color(AsteroidRed, AsteroidGreen, AsteroidBlue); //sets the colors for the asteroid
                    temp.transform.localScale = temp.transform.localScale * Random.Range(smallBoi, bigBoi);
                    if (currentAsteroid > 10000000000)
                    {
                        sending.currentAsteroid = 0;
                        currentAsteroid = 0;
                    }
                    else
                    {
                        sending.currentAsteroid = currentAsteroid + 1;
                        ++currentAsteroid;
                    }
                    temp.name = $"asteroid{currentAsteroid}";
                }
            }
        }
    }
    void Shotgun()
    {
        //Checks if game has ended
        if (didShipDie == false && levelOn == true && delayPowerupShotgun == false)
        {
            //Rng element to spawning
            int z = Random.Range(1, oneInAShotguns + 1);
            //If true, it continues
            if (z == oneInAShotguns)
            {
                //Determines how many shotgun powerups can spawn
                int y = Random.Range(shotgunMinAmount, shotgunMaxAmount);
                //Spawns shotgun powerups
                for (int loop = 0; loop < y; loop++)
                {
                    //Setting position of powerup
                    Vector3 position = new Vector3(Random.Range(-asteroidDepth + centerPointX, asteroidDepth + centerPointX), Random.Range(-powerupSpawnRange + centerPointY, powerupSpawnRange + centerPointY), Random.Range(-powerupSpawnRange + centerPointZ, powerupSpawnRange + centerPointZ));
                    //Spawning and setting timer for powerup
                    var temp = helperPooler.Instance.SpawnFromPool("Shotgun", position, rotationOfPowerups, destroyDelay, y);
                }
            }
        }
    }
    void Shield()
    {
        //Checks if game has ended
        if (didShipDie == false && levelOn == true && delayPowerupShield == false)
        {
            //Rng element to spawning
            int z = Random.Range(1, oneInAShield + 1);
            //If true, it continues
            if (z == oneInAShield)
            {
                //Determines how many powerups can spawn
                int y = Random.Range(shieldMinAmount, shieldMaxAmount);
                //Spawns powerups
                for (int loop = 0; loop < y; loop++)
                {
                    //Setting position of powerup
                    Vector3 position = new Vector3(Random.Range(-asteroidDepth + centerPointX, asteroidDepth + centerPointX), Random.Range(-powerupSpawnRange + centerPointY, powerupSpawnRange + centerPointY), Random.Range(-powerupSpawnRange + centerPointZ, powerupSpawnRange + centerPointZ));
                    //Spawning and setting timer for powerup
                    var temp = helperPooler.Instance.SpawnFromPool("Shield", position, rotationOfPowerups, destroyDelay, y);
                }
            }
        }
    }
    void MP()
    {
        //Checks if game has ended
        if (didShipDie == false && levelOn == true && delayPowerupMP == false)
        {
            //Rng element to spawning
            int z = Random.Range(1, oneInAMP + 1);
            //If true, it continues
            if (z == oneInAMP)
            {
                //Determines how many powerups can spawn
                int y = Random.Range(mPMinAmount, mPMaxAmount);
                //Spawns powerups
                for (int loop = 0; loop < y; loop++)
                {
                    //Setting position of powerup
                    Vector3 position = new Vector3(Random.Range(-asteroidDepth + centerPointX, asteroidDepth + centerPointX), Random.Range(-powerupSpawnRange + centerPointY, powerupSpawnRange + centerPointY), Random.Range(-powerupSpawnRange + centerPointZ, powerupSpawnRange + centerPointZ));
                    //Spawning and setting timer for powerup
                    var temp = helperPooler.Instance.SpawnFromPool("MP", position, rotationOfPowerups, destroyDelay, y);
                }
            }
        }
    }
    void Difficulty()
    {
        //This slowly adds onto the difficulty of the game
        difficulty = difficulty + difficultyRate;
        //This is to cap the difficulty
        if (difficulty > 5)
        {
            CancelInvoke("Difficulty");
        }
    }
    //This allows the level to generate asteroids as it waits to be on
    void Level()
    {
        //Turns off asteroid gen
        levelOn = false;
        //Starts time to turn back on level
        Invoke("Wait", levelWaitTime);
    }
    void Wait()
    {
        //Turns on asteroid gen
        ++sending.currentLevel;
        levelOn = true;
        //Checks if level has reached max capped number
        if (levelTotal < sending.currentLevel)
        {
            InvokeRepeating("Difficulty", 0f, delayForDifficultyRate);
        }
        //Allows normal asteroid gen
        else
        {
            Invoke("Level", levelCompletionTime);
        }
    }
    //This is a small void that can invoke other scripts to be a good tutorial thing for a player, and it's very optional
    void Tutorial()
    {
        if (currentTutorialStage == 3)
        {
            //Hint about structures with lore
            Invoke("Wait", levelWaitTime);
            sending.currentLevel = 1;
            CancelInvoke("Tutorial");
        }
        else if (currentTutorialStage == 2)
        {
            //Enemies and score
            ++currentTutorialStage;
        }
        else if (currentTutorialStage == 1)
        {
            //Asteroid, shooting, powerups
            ++currentTutorialStage;
        }
        else
        {
            //Basic controls
            ++currentTutorialStage;
        }
    }
    void Boss()
    {
        //Starting boss...
    }
}