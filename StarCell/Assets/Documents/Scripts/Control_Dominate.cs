using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Made by PhantomData87
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/
// used by Jetpackdan
// angering dnglchlk slowly, as it gets complicated
public class Control_Dominate : MonoBehaviour
{
    [SerializeField]
    #region Core Functions
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    [Header("Core functions")]
    [Tooltip("Lower the number, higher it runs.\nHigher the number, longer it takes per frame\n-1 for default application frame rate")]
    //Range was not at minimum of -1 before, added in so that application may run natively if it is desired
    [Range(-1, 200)] public int UpdateRate;
    [Tooltip("This key sets what is needed to press to bring in pause menu and to halt the game until otherwise. USE KEYCODE")]
    public string pauseButton;
    [Tooltip("Press a letter for shooting")]
    public string projectileKeyName;

    [TextArea] //Comment 1
    [Tooltip("Put a message here for game, or as reminder")]
    public string Comment1;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Ship Movement
    [Header("Ship movement")]

    [Tooltip("How much momentum will it start with when turning")]
    [Range(0, 200)] public float startTurn;

    [Tooltip("Speed of the ship")]
    [Range(0, 300)] public float speed;

    [Tooltip("Highest momentum value it can reach")]
    [Range(0, 300)] public float maxTurn;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Ship Rotation
    [Header("Ship rotation")]

    [Tooltip("Ship's current Vertical Axis Orientation")]
    public float currentVAxis;

    [Tooltip("Ship's current Horizontal Axis Orientation")]
    public float currentHAxis;
    [Tooltip("Highest Horizontal turn")]
    public float rotateMaxHA;

    [Tooltip("Highest Verticle turn")]
    public float rotateMaxVA;

    [Tooltip("Highest Y turn")]
    public float rotateMaxY;

    [Tooltip("When dynamicly changing opposite directions, how much will the ship resist")]
    public float resistChange;

    [Tooltip("How much can it turn at one time")]
    [Range(0.01f, 1f)] public float constantChange;

    [Tooltip("When no keys are pressed,\nThe Constant change of returning to center are determined by this variable")]
    [Range(0.01f, 20f)] public float noKeyDrag;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Asteroid Movement
    [Header("Asteroid movement")]

    [Tooltip("Determines how fast the asteroids spin")]
    [Range(0.01f, 1f)] public float updateSpeed;

    [Tooltip("Lowest possible rotation speed")]
    public float minSpinSpeed;

    [Tooltip("Highest possible rotation speed")]
    public float maxSpinSpeed;

    [Tooltip("Constant turning speed")]
    public float spinSpeed;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Asteroid Generation Config
    [Header("Asteroid Generation Config")]

    [Tooltip("How wide the field of asteroids can be")]
    [Range(0, 10000)] public float rangeAsteroid;

    [Tooltip("How long across can the asteroids spawn within")]
    public float asteroidDepth;

    [Tooltip("How long until asteroids self-destruct themselves")]
    public float destroyDelay;

    [Tooltip("The number of asteroids times 20")]
    public int asteroidCount;

    [Tooltip("How often asteroids spawn")]
    public float spanwTime;

    [Tooltip("Minimum size for asteroid")]
    public float smallBoi;

    [Tooltip("Maximum size for asteroid")]
    public float bigBoi;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Asteroid Generation Config Part 2
    [Header("Asteroid Generation Config Part 2")]

    [Tooltip("Minimum size for tiny asteroid")]
    public float jrSmallBoi;

    [Tooltip("Maximum size for tiny asteroid")]
    public float jrBigBoi;

    [Tooltip("How much speed does the new asteroid go with")]
    public int jrSpeed;

    [Tooltip("How many can spawn once asteroid is destroyed")]
    public int spawnAmount;

    [Tooltip("The minimum distance away from the original asteroid's center")]
    public int minSpawnRange;

    [Tooltip("This is to determine when to spawn a tinier asteroid from one of the more recently destroyed asteroids")]
    public float asteroidSizeToSpawnMore;

    [Tooltip("How much time will the newly spawned asteroids stay")]
    public int newAsteroidDecay;

    [Tooltip("Offset for asteroid's origin from initial asteroid")]
    public Vector3 newAsteroidOffset;

    [Tooltip("The minimum thrust the newly spawned asteroids")]
    public int minThrustJr;

    [Tooltip("The maximum thrust the newly spawned asteroids")]
    public int maxThrustJr;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Shooting Calibration
    [Header("Shooting calibration")]

    [Tooltip("The starter axis of the projectile that will be spawned")]
    public Vector3 ProjectileAxis;


    [Tooltip("The offset of the first projectile axis's from the ship when key is pressed")]
    public Vector3 firstProjectileOffSet;

    [Tooltip("To enable/disable second projectile")]
    public bool secondProjectileActive;

    [Tooltip("the offset for the second projectile ")]
    public Vector3 secondProjectileOffSet;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Projectile Config
    [Header("Projectile Config")]

    [Tooltip("How long until object dissapears")]
    public float projectileDecay;

    [Tooltip("The max ammo the player can have and start with")]
    public long ammo;

    [Tooltip("Regenration rate of projectile that were shot")]
    public float regenOfProjectileRate;

    [Tooltip("Speed of projectile")]
    public int projectilesSpeed;

    [Tooltip("The speed you can shoot at.")]
    public float shootingSpeed;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Shotgun Spawn Config
    [Header("Shotgun spawn config")]

    [Tooltip("how many get shot with one press")]
    public int shotGunShotsTotal;

    [Tooltip("the random Y spread")]
    public int YaxisShotgunSpreadSeter;

    [Tooltip("the random X spread")]
    public int ZaxisShotgunSpreadSeter;

    [Tooltip("the pellet decay for the shotgun")]
    public float shotgunprojectileDecay;

    [Tooltip("Decides how often do powerups spawn based on time")]
    public int shotgunSpawnTimer;

    [Tooltip("How many powerups of shotgun can spawn")]
    public int shotgunMaxAmount;

    [Tooltip("How many Shotguns atleast can spawn")]
    public int shotgunMinAmount;

    [Tooltip("One in a number that you decide that the shotgun powerup will spawn")]
    public int oneInAShotguns;

    [Tooltip("Does this powerup need a button")]
    public bool buttonNeededS;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Shield Spawn Configs
    [Header("Shield spawn config")]
    [Tooltip("How many powerups of shield can spawn")]
    public int shieldMaxAmount;
    [Tooltip("How many Shields atleast can spawn")]
    public int shieldMinAmount;
    [Tooltip("Decides how often do powerups spawn based on time")]
    public int shieldSpawnTimer;
    [Tooltip("One in a number that you decide that the shield powerup will spawn")]
    public int oneInAShield;
    [Tooltip("Does this powerup need a button")]
    public bool buttonNeededSh;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Massive Projectile Spawn Config
    [Header("Massive Projectile spawn config")]

    [Tooltip("How fast does the newly spawn projectile can spawn")]
    public int projectilesMassiveSpeed;
    [Tooltip("How many powerups of MP can spawn")]
    public int mPMaxAmount;
    [Tooltip("How many MP's atleast can spawn")]
    public int mPMinAmount;
    [Tooltip("Decides how often do powerups spawn based on time")]
    public int mPSpawnTimer;
    [Tooltip("One in a number that you decide that the MP powerup will spawn")]
    public int oneInAMP;
    [Tooltip("How big will the projectile be")]
    public float massiveProjectileSize;
    [Tooltip("A offset for massive projectile, only the x-axis")]
    public float massiveOffset;
    [Tooltip("Does this powerup need a button")]
    public bool buttonNeededMP;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Powerup General
    [Header("Powerup General")]
    [Tooltip("A key for powerup")]
    public string projectileKeyNameShot;
    [Tooltip("A key for powerup")]
    public string projectileKeyNameShield;
    [Tooltip("A key for powerup")]
    public string projectileKeyNameMp;
    [Tooltip("How long of a delay until the shotgun powerup stops firing shotgun pellets")]
    public float shotgunStopDelay;
    [Tooltip("Sets custom range of power up spawning")]
    [Range(10, 3000)] public float powerupSpawnRange;
    [Tooltip("If false, than it spawns no matter what level. If true, than it waits for 'betterPowerupStartLevel'")]
    public bool delayPowerupShotgun;
    [Tooltip("Damage for every shotgun projectile")]
    public float shotgunDmg;
    [Tooltip("How many seconds until shotgunDampenerDmgRate begins")]
    public float shotgunDampenerDelay;
    [Tooltip("How much dmg it losses per second")]
    public float shotgunDampenerDmgRate;
    [Tooltip("How long of a delay until the shield powerup stops protecting player")]
    public float shieldStopDelay;
    [Tooltip("If false, than it spawns no matter what level. If true, than it waits for 'betterPowerupStartLevel'")]
    public bool delayPowerupShield;
    [Tooltip("How many hits shield can accept before auto destroying")]
    public int shieldMaxHit;
    [Tooltip("How long of a delay until the MP powerup stops firing a MP")]
    public float mPStopDelay;
    [Tooltip("If false, than it spawns no matter what level. If true, than it waits for 'betterPowerupStartLevel'")]
    public bool delayPowerupMP;
    [Tooltip("How much damage MP can cause per hit")]
    public int mpDmg;
    [Tooltip("The rotation of how the powerup will spawn")]
    public Quaternion rotationOfPowerups = Quaternion.identity;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Level Config
    [Header("Level configuration")]
    [Tooltip("To skip the tutorial")]
    public bool skipTutorial;
    [Tooltip("Determines how much time the player has to wait before the next tutorial section loads")]
    public float delayTutorial;
    [Tooltip("This determines how hard is everything. For example, a difficulty of 1 will affect nothing, while 3 will massively impact on the player by putting harder things. For example, on asteroidHealth, it will be multiplied by difficulty")]
    [Range(1, 3)] public float difficulty;
    [Tooltip("How much the difficult will slowly increase after passing all levels")]
    public int difficultyRate;
    [Tooltip("How much of a delay after player beaten level before difficulty increases")]
    public float delayForDifficultyRate;
    [Tooltip("How many more hits")]
    public float asteroidHealth;
    [Tooltip("How fast the health will increase")]
    public float asteroidHealthRate;
    [Tooltip("How many total levels there are before a specific final event happens")]
    public int levelTotal;
    [Tooltip("How much time each level deserves")]
    public float levelCompletionTime;
    [Tooltip("How much wait time between each level")]
    public float levelWaitTime;
    [Tooltip("When will the better powerups can spawn")]
    public int betterPowerupStartLevel;
    [Tooltip("When will the enemy be able to spawn at")]
    public int enemyStartLevel;
    [Tooltip("How likely structures can spawn")]
    public int structureSpawnRate;
    [Tooltip("How likely rare structures can spawn")]
    public int rareStructureSpawnRate;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Currency Config
    [Header("Currency config")]
    [Tooltip("The rotation of the token when spawned")]
    public Quaternion rotationOfToken;
    [Tooltip("How fast the projectile moves towards the player")]
    public float followSpeed;
    [Tooltip("Distance needed for the token and the player detect each other")]
    public float distanceOfTokenToPlayer;
    [Tooltip("How big the token is")]
    public int tokenSize;
    [Tooltip("Debug when tokens are saved and retrieved in console")]
    public bool tokenSaveDebug;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Enemy Config
    [Header("Enemy configuration")]
    [Tooltip("How likely it will be for enemies to spawn")]
    public int enemySpawnRate;
    [Tooltip("Minimum Speed of current enemy")]
    public float enemyMinSpeed;
    [Tooltip("Maximum Speed of current enemy")]
    public float enemyMaxSpeed;
    [Tooltip("How much time before boss level is generated")]
    public float delayForBoss;
    #endregion
    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    #region Variables that are not to see
    [TextArea]//This area is hidden from player
    [Tooltip("Put a message here for game, or as reminder")]
    public string Comment2;
    [HideInInspector]
    public int cloneAddingPew;
    [HideInInspector]
    public int currentAsteroid;
    [HideInInspector]
    public bool shotgunActive;
    [HideInInspector]
    public bool shieldActive;
    [HideInInspector]
    public bool mPActive;
    [HideInInspector]
    public bool didShipDie;
    [HideInInspector]
    public bool nameReceived;
    [HideInInspector]
    public bool useSameName;
    [HideInInspector]
    public bool leaveReceived;
    [HideInInspector]
    public bool leaderReceived;
    [HideInInspector]
    public bool retryReceived;
    [HideInInspector]
    public float currentAmmo;
    [HideInInspector]
    public int currentLevel;
    [HideInInspector]
    public int gameScore;
    [HideInInspector]
    public string gameName;
    [HideInInspector]
    public bool buttonPressed;
    [HideInInspector]
    public bool earlyNameMaybeDone;
    [HideInInspector]
    public int currency;
    [HideInInspector]
    public int tokenCount;
    #endregion
    void Awake()
    {
        shotgunActive = false;
        Application.targetFrameRate = UpdateRate;
    }
}
