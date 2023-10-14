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
    
    //public event EventHandler OnUse;
    //public event EventHandler OnRemove;


    void Awake()
    {
        //EventSystem.current.SetSelectedGameObject(gameObject);

        removeButton.onClick.AddListener(OnRemoveClick);
        useButton.onClick.AddListener(OnUseClick);
        //OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    /*
    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Mouse was clicked outside");
    }*/

    void OnRemoveClick()
    {
		StaticEvents.Collecting.OnItemRemove?.Invoke(itemBase);
	}
    void OnUseClick()
    {
		StaticEvents.Collecting.OnItemUse?.Invoke(itemBase);
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
