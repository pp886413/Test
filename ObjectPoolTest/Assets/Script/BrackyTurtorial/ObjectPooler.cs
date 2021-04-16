using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    // Object pool data information
    [System.Serializable]
    public struct PoolData
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<PoolData> poolData; // Pool object data list

    private Dictionary<string, Queue<GameObject>> poolDictionary = new Dictionary<string, Queue<GameObject>>();

    // Singleton
    #region
    public static ObjectPooler instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    //delegate
    public delegate void SpawnStartDelegate();
    public SpawnStartDelegate spawnStartDelegate;


    private void Start()
    {
        ObjectPoolInitialize();
    }

    // Initialize object 
    public void ObjectPoolInitialize()
    {
        // Each pool element 
        foreach (PoolData poolElement in poolData)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < poolElement.size; i++)
            {
                GameObject obj = Instantiate(poolElement.prefab, this.gameObject.transform); // Spawn pre object

                obj.SetActive(false); // Disable Object

                objectPool.Enqueue(obj); // Add object to game object queue
            }

            poolDictionary.Add(poolElement.tag, objectPool); //Add object to dictionary
        }
        Debug.Log("PoolDictionary size is :" + poolDictionary.Count);
    }

    //Spawn taged object on pool  
    public GameObject GetObjectFromPool(string tag , Vector3 SpawnPosition , Quaternion SpawnRotation)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            return null;
        }

        GameObject ObjectToSpawn = poolDictionary[tag].Dequeue(); // Take dictionary's object  

        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = SpawnPosition;
        ObjectToSpawn.transform.rotation = SpawnRotation;

        //spawnStartDelegate();

        poolDictionary[tag].Enqueue(ObjectToSpawn); // Add object into dictionary 

        return ObjectToSpawn;
    }

    public void RetrieveFromSpawn(string tag)
    {
        GameObject objectToRetrieve = poolDictionary[tag].Dequeue();

        objectToRetrieve.SetActive(false);

        poolDictionary[tag].Enqueue(objectToRetrieve);
    }
    public void UnActiveAllPool(string tag)
    {
        GameObject unActiveObject;
        foreach (PoolData poolElement in poolData)
        {
            for (int i = 0; i < poolElement.size; i++)
            {
                unActiveObject = poolDictionary[tag].Dequeue();

                unActiveObject.SetActive(false);

                poolDictionary[tag].Enqueue(unActiveObject);
            }
        }
        Debug.Log("Have deActive object");
    }
    public void RemovePoolDictionary()
    {
        poolDictionary.Clear();
        Debug.Log("Have clear poolDictionary length");
    }
}
