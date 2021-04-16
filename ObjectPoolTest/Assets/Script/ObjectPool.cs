using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField]
    private GameObject BlockPrefab = null;

    [SerializeField]
    private Queue<GameObject> BlockPool = new Queue<GameObject>();

    [SerializeField]
    private int BlockStartSize = 5;

    private void Start()
    {
        InstancePoolObject();
    }

    private void InstancePoolObject()
    {
        for (int i = 0; i < BlockStartSize; i++)
        {
            GameObject NewBlock = Instantiate(BlockPrefab);

            BlockPool.Enqueue(NewBlock);
            NewBlock.SetActive(false);
        }
    }
    public GameObject GetPoolObject()
    {
        if (BlockPool.Count > 0)
        {
            GameObject NewBlock = BlockPool.Dequeue();
            NewBlock.SetActive(true);
            return NewBlock;
        }
        else
        {
            GameObject NewBlock = Instantiate(BlockPrefab);
            return NewBlock;
        }
    }
    private void ReturnPoolObject(GameObject Object)
    {
        Object.SetActive(true);
        BlockPool.Enqueue(Object);
    }

}
