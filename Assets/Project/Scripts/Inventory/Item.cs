using UnityEngine;
using System;

[Serializable]
public class Item
{
    public ItemType type;
    public int amount;
    public bool canStack = false;
    public Sprite sprite;

    public void CreateItem(ItemBase itemBase)
    {
        this.type = itemBase.type;
        this.amount = itemBase.amount;
        this.canStack = itemBase.canStack;
        this.sprite = itemBase.sprite;
    }


    //CHANGE
    public Sprite GetSprite()
    {
        return sprite;

        //get sprite from database by type
        /*switch(type)
        {
            default:
            case ItemType.HealthPotion: return ItemAssets.Instance.healthPotionSprite;
            case ItemType.ManaPotion:   return ItemAssets.Instance.manaPotionSprite;
            case ItemType.Medkit:       return ItemAssets.Instance.medkitSprite;
            case ItemType.Sword:        return ItemAssets.Instance.swordSprite;
            case ItemType.Coin:         return ItemAssets.Instance.coinSprite;
        }*/
    }


    //CHANGE
    public bool IsStackale()
    {
        return canStack;
        
        /*
        //get sprite from database by type
        switch(type)
        {
            default:
            case ItemType.HealthPotion: return true;
            case ItemType.ManaPotion:   return true;
            case ItemType.Medkit:       return false;
            case ItemType.Sword:        return false;
            case ItemType.Coin:         return true;
        }*/
    }

    public static Item Clone(Item originalItem)
    {
        Item copyItem = new Item();
        copyItem.type = originalItem.type;
        copyItem.amount = originalItem.amount;
        copyItem.canStack = originalItem.canStack;
        return copyItem;
    }
    public Item Clone()
    {
        return Clone(this);
    }
}
