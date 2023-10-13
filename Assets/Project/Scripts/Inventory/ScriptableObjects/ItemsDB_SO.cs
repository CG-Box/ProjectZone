using System.Linq;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemsDB_SO", menuName = "SriptableObjects/ItemsDatabase_SO", order = 7)]
public class ItemsDB_SO : ScriptableObject
{
    [SerializeField]
    private List<ItemData_SO> itemsViewList; //only for viewing in the inspector
    private Dictionary<ItemType, ItemData_SO> itemsDatabase;

    [ContextMenu("GenerateDatabase")]
    public void CollectItemsFromFolder()
    {
        itemsViewList = Resources.LoadAll<ItemData_SO>(path: "ItemsData").OrderBy(item => item.Data.type).ToList();
        itemsDatabase = itemsViewList.ToDictionary(keySelector: item => item.Data.type, elementSelector: item => item);
    }

    public ItemBase GetItemData(ItemType type)
    {
        return itemsDatabase[type].Data;
    }
}
