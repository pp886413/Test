using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dot : MonoBehaviour
{
    [SerializeField] private List<GameObject> objectList = null;

    private void Update()
    {
        float resentDotValue = Quaternion.Dot(transform.rotation, objectList[0].transform.rotation);
        for (int i = 0; i < objectList.Count; i++)
        {
            float dotValue = Quaternion.Dot(transform.rotation, objectList[i].transform.rotation);

            if (dotValue < resentDotValue)
            {
                resentDotValue = dotValue;
                Debug.Log(resentDotValue);
            }
        }
    }
}
