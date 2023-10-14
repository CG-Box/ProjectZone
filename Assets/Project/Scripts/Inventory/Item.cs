using UnityEngine;
using System;


[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [Header("Require ItemData_SO")]

    [SerializeField]
    private ItemData_SO itemToGenerate;
    ItemBase itemBase;
    public ItemBase Data
    {
        get { return itemBase; }
    }

    //public Action BeforeDestroyFunction;

    void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        GenerateItemByItemData_SO(itemToGenerate);
        UpdateItemVisual();
    }

    [ContextMenu("GenerateItem")]
    public void GenerateItemByItemData_SO()
    {
        GenerateItemByItemData_SO(itemToGenerate);
    }
    public void GenerateItemByItemData_SO(ItemData_SO itemData_SO)
    {
       if(itemData_SO)
       {
            SetItem(itemData_SO);
            UpdateItemVisual();
       }/*
       else
       {
            Debug.LogError("Can't generate item by empty ItemData_SO");
       }*/
    }

    public void SetItem(ItemBase itemBase)
    {
        this.itemBase = itemBase;
    }
    public void SetItem(ItemData_SO itemData_SO)
    {
        this.itemBase = itemData_SO.Data;
    }
    public void UpdateItemVisual()
    {
        spriteRenderer.sprite = itemBase.sprite;
    }

    public void DestroySelf()
    {
        //BeforeDestroyFunction?.Invoke();
        Destroy(gameObject);
    }
}
