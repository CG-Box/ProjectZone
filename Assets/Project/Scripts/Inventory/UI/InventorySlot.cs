using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour
{

    [SerializeField]
    private Image slotImage;

    [SerializeField]
    private TextMeshProUGUI slotStackText;

    [SerializeField]
    private Button removeButton;

    [SerializeField]
    private Button useButton;

    ItemBase itemBase;
    
    public event EventHandler<ItemSlotEventArgs> OnUseSlotItem;
    public event EventHandler<ItemSlotEventArgs> OnRemoveSlotItem;


    void OnEnable()
    {
        removeButton.onClick.AddListener(OnRemoveClick);
        useButton.onClick.AddListener(OnUseClick);
    }
    void OnDisable()
    {
        removeButton.onClick.RemoveListener(OnRemoveClick);
        useButton.onClick.RemoveListener(OnUseClick);
    }

    /*
    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(gameObject);
    }
    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Mouse was clicked outside");
    }*/

    void OnRemoveClick()
    {
        OnRemoveSlotItem?.Invoke(this, new ItemSlotEventArgs(this.itemBase));
	}
    void OnUseClick()
    {
        OnUseSlotItem?.Invoke(this, new ItemSlotEventArgs(this.itemBase));
	}

    public void HideControlButtons()
    {
        transform.parent.gameObject.SetActive(false);
    }


    public void SetSlotItem(ItemBase itemBase)
    {
        this.itemBase = itemBase;
    }
    public void UpdateSlotVisual()
    {
        slotImage.sprite = itemBase.sprite;
        if(itemBase.amount > 1)
        {
            slotStackText.SetText(itemBase.amount.ToString());
        }
        else
        {
            slotStackText.SetText("");
        }
    }
}

public class ItemSlotEventArgs : EventArgs
{
    public ItemBase itemBase;
    public ItemSlotEventArgs(ItemBase itemBase)
    {
        this.itemBase = itemBase;
    }
}
