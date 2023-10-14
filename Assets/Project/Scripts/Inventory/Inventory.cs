using UnityEngine;
using System.Collections.Generic;
using System;

public class Inventory
{    
    List<ItemBase> itemList;

    public event EventHandler OnItemListChanged;

    public Inventory()
    {
        itemList = new List<ItemBase>();

        //AddItem(new ItemBase{type = ItemType.Medkit, amount = 1});
    }

    public void AddItem(ItemBase newItem)
    {   
        if(newItem.canStack)
        {   
            bool alreadyExist = false;
            for (int i = 0; i < itemList.Count; i++)
            {
                ItemBase currentItem = itemList[i];
                if(currentItem.type == newItem.type)
                {
                    alreadyExist = true;
                    currentItem.amount += newItem.amount;
                    itemList[i] = currentItem;
                }
            }

            if(!alreadyExist)
            {
                itemList.Add(newItem);
            }
        }
        else
        {
            itemList.Add(newItem);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        PrintInventoryToDebug();
    }
    public void RemoveItem(ItemBase delItem)
    {   
        if(delItem.canStack)
        {   
            for (int i = 0; i < itemList.Count; i++)
            {
                ItemBase currentItem = itemList[i];
                if(currentItem.type == delItem.type)
                {
                    currentItem.amount -= delItem.amount;
                    itemList[i] = currentItem;
                    if(currentItem.amount <= 0)
                        itemList.Remove(currentItem);
                    break;
                }
            }
        }
        else
        {
            itemList.Remove(delItem);
        }
        OnItemListChanged?.Invoke(this, EventArgs.Empty);

        PrintInventoryToDebug();
    }

    public void PrintInventoryToDebug()
    {
        Debug.Log("*** INVENTORY ***");
        foreach(ItemBase item in itemList)
        {
            Debug.Log($"item type: {item.type} amount: {item.amount}");
        }
    }
    
    public List<ItemBase> GetItemList()
    {
        return itemList;
    }
    public void LoadItemList(List<ItemBase> loadItemList)
    {
        itemList = loadItemList;
        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
}
