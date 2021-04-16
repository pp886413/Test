using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public string spawnTag;

    private ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;

        objectPooler.spawnStartDelegate = PrintWhenSpawn;

        //StartCoroutine("GetObject");
    }

    /*private IEnumerator GetObject()
    {
        float spawnTime = 0.0f;
        float loopDuration = 3.0f;

        while (spawnTime < loopDuration)
        {
            spawnTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }

        objectPooler.GetObjectFromPool(spawnTag, transform.position, Quaternion.identity);
        spawnTime = 0.0f;
        StartCoroutine("GetObject");
    }*/
    public void GetObject()
    {
        objectPooler = ObjectPooler.instance;
        objectPooler.GetObjectFromPool(spawnTag, transform.position, Quaternion.identity);
    }

    private void PrintWhenSpawn()
    {
        Debug.Log("I am spawning now");
    }
}
