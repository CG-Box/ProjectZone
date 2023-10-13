using UnityEngine;
public struct ItemBase
{
    public readonly ItemType type;
    public readonly Sprite sprite;
    public readonly bool canStack;
    public int amount;

    public ItemBase(ItemType type, Sprite sprite)
    {
        this.type = type;
        this.sprite = sprite;
        this.canStack = false;
        this.amount = 1; 
    }
    public ItemBase(ItemType type, Sprite sprite, bool canStack)
    {
        this.type = type;
        this.sprite = sprite;
        this.canStack = canStack;
        this.amount = 1; 
    }
    public ItemBase(ItemType type, Sprite sprite, bool canStack, int amount)
    {
        this.type = type;
        this.sprite = sprite;
        this.canStack = canStack;
        this.amount = amount;
    }

    public void PrintToLog()
    {
        Debug.Log($"ItemType: {type}, canStack: {canStack}, amount: {amount}, sprite: {sprite.name}");
    }
}