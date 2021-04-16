using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [Range(0,3)]
    public float size;

    public void SetRandomColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Random.ColorHSV();
    }
    public void ResetColor()
    {
        GetComponent<Renderer>().sharedMaterial.color = Color.gray;
    }
    public void ScaleSize()
    {
        transform.localScale = Vector3.one * size;
    }
}
