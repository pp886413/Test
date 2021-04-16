using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour,ITest
{
    private void Start()
    {
        IEffect();
    }
    public void IEffect()
    {
        Debug.Log("IEffect() is working");
    }
}
