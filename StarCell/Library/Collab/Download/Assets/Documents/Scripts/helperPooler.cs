using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
      _                                                            _______
     | |                                        |                 /  \   /
  _  | |     __,   _  _  _|_  __   _  _  _    __|   __, _|_  __,  \__/  / 
|/ \_|/ \   /  |  / |/ |  |  /  \_/ |/ |/ |  /  |  /  |  |  /  |  /  \ /  
|__/ |   |_/\_/|_/  |  |_/|_/\__/   |  |  |_/\_/|_/\_/|_/|_/\_/|_/\__//  o
/|                                                                   /
\|
*/
public class helperPooler : MonoBehaviour
{
    //Prepares objects that are set to be "deactivated"
    public Queue<GameObject> objectUnpool = new Queue<GameObject>();
    //Saves variables
    [System.Serializable]
    //Core function of object pooling, it saves different prefabs on the inspector of unity
    public class Pool
    {
        public string tag;
        public int size;
        public GameObject prefab;
    }

    //To make a singleton
    #region Singleton

    public static helperPooler Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion
    // ^^^

    //Makes a list called "pools" for the entire list of Pool
    public List<Pool> pools;
    //Makes a directory for all of the gameObjects present in the game's running time
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    // Start is called before the first frame update
    void Start()
    {
        //Makes sure it's empty
        objectUnpool = new Queue<GameObject>();
        //Makes a new directory for each game and makes it empty
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        //Verifies every list instance in "pools" and saves it as a "pool"
        foreach (Pool pool in pools)
        {
            //Makes a temporarly queue list
            Queue<GameObject> objectPool = new Queue<GameObject>();
            //Verification for the amount of required objects to be spawned. It's based on tag
            for (int i = 0; i < pool.size; i++)
            {
                //Instantiates the object
                GameObject obj = Instantiate(pool.prefab);
                //Gives it a tag to be called again
                obj.tag = pool.tag;
                //Set's the object to not be active
                obj.SetActive(false);
                //Saves the object to a list
                objectPool.Enqueue(obj);
            }
            //The list that was slowly being built, is now dumpted into the poolDirectory directory
            poolDictionary.Add(pool.tag, objectPool);
        }
    }
    //This is where all instances where a object needs to be called is summoned here. Based on tag, position, rotation, how long it can last and how many it needs for the operation
    public GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation, float destroyDelay, int requiredNeed)
    {
        //Checks if there is a valid tag, to prevent crash
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log(tag);
            Debug.LogWarning("Pool with tag " + tag + " doesn't exist.");
            return null;
        }
        //This is to make sure that there are enought gamebjects for required task
        foreach (Pool pool in pools)
        {
            //Checks how many objects are needed
            if(poolDictionary[tag].Count < requiredNeed)
            {
                for (int i = poolDictionary[tag].Count; i < requiredNeed; i++)
                {
                    if(tag == pool.tag)
                    {
                        GameObject obj = Instantiate(pool.prefab);
                        obj.tag = tag;
                        obj.SetActive(false);    
                        poolDictionary[tag].Enqueue(obj);    
                        break;
                    }
                }
            }
        }
        //Grabs the gameObject that is being summon and de-queues it from poolDirectory list
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        //Sets the position
        objectToSpawn.transform.position = position;
        //Sets the rotation
        objectToSpawn.transform.rotation = rotation;
        //Activates gameObject
        objectToSpawn.SetActive(true);
        //Prepares the removal of gameObject
        objectUnpool.Enqueue(objectToSpawn);
        Invoke("toReturn", destroyDelay);
        //Enqueues gameObjetc so it can be used again
        poolDictionary[tag].Enqueue(objectToSpawn);
        //That's it
        return objectToSpawn;
    }

    void toReturn()
    {
        //Dequeue's object
        var obj = objectUnpool.Dequeue();
        //Sets it back to false
        if (obj.activeSelf == true)
        {
            obj.SetActive(false);
        }
    }
}