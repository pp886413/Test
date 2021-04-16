using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookObject : MonoBehaviour
{
    [SerializeField]
    private Transform o2_Transform = null;

    private void FaceObject()
    {
        Vector3 direction = o2_Transform.position - transform.position;
        Debug.DrawRay(transform.position, direction, Color.green);

        transform.rotation = Quaternion.LookRotation(direction);
    }

    private void Update()
    {
        FaceObject();
    }
}
