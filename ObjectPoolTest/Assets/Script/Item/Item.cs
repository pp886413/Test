using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour , IInteract
{
    public ItemData itemData;

    [SerializeField]
    private int itemQuantity = 0;

    public void InteractEffect()
    {
        Debug.Log("Pick " + gameObject.name + " Up");

        Destroy(gameObject);
    }
}
