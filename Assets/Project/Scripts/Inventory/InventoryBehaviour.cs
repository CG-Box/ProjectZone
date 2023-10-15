using UnityEngine;
using System.Collections.Generic;

public class InventoryBehaviour : MonoBehaviour,IDataPersistence
{
    private Inventory inventory;

    [SerializeField]
    private Transform itemPrefab;

    [SerializeField]
    private ItemsDB_SO itemsDatabase;

    [SerializeField]
    private InventoryPanel inventoryPanel;

    void  Awake() 
    {
        inventory = new Inventory();   

        inventoryPanel.SetInventoryBehaviour(this);
        inventoryPanel.SetInventory(inventory);
    }

    void OnEnable()
    {
        StaticEvents.Collecting.OnItemUse += UseItem;
        StaticEvents.Collecting.OnItemRemove += RemoveItem;
        StaticEvents.Spawning.OnSpawnItem += DropItem;
    }  
    void OnDisable()
    {
        StaticEvents.Collecting.OnItemUse -= UseItem;
        StaticEvents.Collecting.OnItemRemove -= RemoveItem;
        StaticEvents.Spawning.OnSpawnItem -= DropItem;
    }

    public void UseItem(ItemBase item)
    {
        switch(item.type)
        {
            default:
            case ItemType.Ammo:
                inventory.RemoveItem(item);
                if(inventory.DoesNotContain(item))
                    StaticEvents.Collecting.OnOutOfAmmo?.Invoke();
                break;
            case ItemType.Medkit:
                float medkitHealth = 50f;
                StaticEvents.PlayerHealth.OnRestoreHealth?.Invoke(medkitHealth, this.gameObject);
                inventory.RemoveItem(new ItemBase(ItemType.Medkit,null,true,1));
                break;
        }
    }
    public void UseItem(ItemBase item, GameObject targetObject)
    {   
        if(gameObject == targetObject)
            UseItem(item);
    }
    public void RemoveItem(ItemBase item)
    {
         inventory.RemoveItem(item);
            if(inventory.DoesNotContain(item))
                StaticEvents.Collecting.OnOutOfAmmo?.Invoke();
        DropItem(item, transform.position);
        //inventory.PrintInventoryToDebug();
    }
    public void RemoveItem(ItemBase item, GameObject targetObject)
    {
        if(gameObject == targetObject)
            RemoveItem(item);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        Item collectable = collider.GetComponent<Item>();
        if(collectable != null)
        {
            ItemBase collectedItem = collectable.Data;
            StaticEvents.Collecting.OnItemCollect?.Invoke(collectedItem);
            inventory.AddItem(collectedItem);
            collectable.DestroySelf();
        }
    }

    public Item SpawnItem(ItemBase item, Vector3 position)
    {
        Transform itemTransform = Instantiate(itemPrefab, position, Quaternion.identity);

        Item collectable = itemTransform.GetComponent<Item>();
        collectable.SetItem(item);
        collectable.UpdateItemVisual();
        return collectable;   
    }

    public Item DropItem(ItemBase item, Vector3 dropPosition)
    {
        float x = Random.Range(-1f, 1f);
        float y = Random.Range(-1f, 1f);
        Vector3 randomDir = new Vector3(x, y, 0f);
        randomDir = randomDir.normalized * 2f;

        return SpawnItem(item, dropPosition + randomDir );
    }


    //Player Inventory Saver
    public void LoadData(GameData data)
    {   
        List<ItemBase> inventoryList = new List<ItemBase>();
        foreach (ItemBase item in data.globals.itemList)
        {
            ItemBase inventoryItem = itemsDatabase.GetItemData(item.type);
            inventoryItem.amount = item.amount;
            inventoryList.Add(inventoryItem);
        }
        inventory.LoadItemList(inventoryList);
    }

    public void SaveData(GameData data)
    {
        data.globals.itemList = inventory.GetItemList();
    }
}
