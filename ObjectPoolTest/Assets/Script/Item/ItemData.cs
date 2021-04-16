using UnityEngine;

public enum EItemType
{ 
    Buff,
    Message,
    Comsumable
}
 
[CreateAssetMenu(fileName = "New Data", menuName = "Item")]
public class ItemData : ScriptableObject
{
    public int id;
    public string itemName;
    public Sprite itemImage;
    public EItemType itemType;
    public string itemDescription;
}
