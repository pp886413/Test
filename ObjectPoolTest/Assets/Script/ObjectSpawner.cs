using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField]
    private float SpawnTime = 3;

    private float TimeSinceSpawn = 0.0f;

    private ObjectPool objectPool;

    private void Start()
    {
        objectPool = FindObjectOfType<ObjectPool>();
    }

    private void Update()
    {
        TimeSinceSpawn += Time.deltaTime;

        if (TimeSinceSpawn > SpawnTime)
        {
            GameObject NewBlock = objectPool.GetPoolObject();
            NewBlock.transform.position = this.transform.position;

            TimeSinceSpawn = 0.0f;
        }
    }
}
