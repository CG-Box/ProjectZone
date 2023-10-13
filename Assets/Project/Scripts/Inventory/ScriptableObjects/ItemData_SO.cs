using UnityEngine;

public enum ItemType 
{
    Makarov,
    Medkit,
    Ammo,
    Ak47,
    Helmet,
    Cloak,
    Pants,
    Elbow,
    Wrist,
    Bag
}

[CreateAssetMenu(fileName = "ItemData_SO", menuName = "SriptableObjects/ItemData_SO", order = 2)]
public class ItemData_SO: ScriptableObject
{
    [SerializeField]private ItemType type;
    [SerializeField]private Sprite sprite;
    [SerializeField]private bool canStack = false;

    [SerializeField]private int amount = 1;

    //public static Transform CollectableTransform;

    ItemBase itemBase;

    public ItemBase Data
    {
        get { return itemBase; }
    }

    void OnEnable()
    {
        itemBase = new ItemBase(type, sprite, canStack, amount);
    }
    //void OnValidate(){} //Every change in SO
}
