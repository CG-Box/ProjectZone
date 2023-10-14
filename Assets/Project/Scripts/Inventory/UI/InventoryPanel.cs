using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryPanel : MonoBehaviour
{

    private Inventory inventory;

    [SerializeField]private Transform itemsContainer;
    [SerializeField]private Transform itemTemplate;

    [SerializeField]private float slotSize = 50f;
    [SerializeField]private int amountInLine = 7;

    private InventoryBehaviour inventoryBehaviour;

    [SerializeField]private ItemsDB_SO itemsDatabase;

    public void SetInventoryBehaviour(InventoryBehaviour inventoryBehaviour)
    {
        this.inventoryBehaviour = inventoryBehaviour;
    }

    public void SetInventory(Inventory inventory)
    {
        this.inventory = inventory;

        inventory.OnItemListChanged += InventoryPanel_OnListChanged;

        Refresh();
    }

    private void InventoryPanel_OnListChanged(object sender, System.EventArgs e)
    {
        Refresh();
    }

    private void Refresh()
    {
        foreach(Transform child in itemsContainer)
        {
            Destroy(child.gameObject);
        }
        
        foreach(ItemBase item in inventory.GetItemList())
        {
            RectTransform itemSlotRectTransform = Instantiate(itemTemplate, itemsContainer).GetComponent<RectTransform>();
            //itemSlotRectTransform.gameObject.SetActive(true);
            InventorySlot inventorySlot = itemSlotRectTransform.gameObject.GetComponent<InventorySlot>();

            inventorySlot.SetSlotItem(item);
            inventorySlot.UpdateSlotVisual();
            
            /*
            ClickableObject clickObj = itemSlotRectTransform.GetComponent<ClickableObject>();
            clickObj.LeftClickFunction = () => {
                //Debug.Log("Left click item: "+item.type.ToString());
            };
            clickObj.MiddleClickFunction = () => {
                Drop(item);
            };
            clickObj.RightClickFunction = () => {
                Use(item);
            };*/
        }
    }

    /*
    public void Drop(Item item)
    {
        //Item duplicateItem = new Item {type = item.type, amount = item.amount};
        inventory.RemoveItem(item);

        Debug.Log($"CHANGE THIS");
        //InventoryCollectable.DropItem(duplicateItem, inventoryBehaviour.gameObject.transform.position);
    }
    public void Use(Item item)
    {
        inventory.UseItem(item);
    }*/
 
}
