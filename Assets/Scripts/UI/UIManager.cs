using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Inventory System")]
    public GameObject inventoryPanel;
    public InventorySlot[] toolSlots;
    public InventorySlot[] itemSlots;
    public Text itemNameText;
    public Text itemDescriptionText;

    private void Awake()
    {
        // If there is more than one instance, destroy the extra
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // Set the static instance to this instance
            Instance = this;
        }
    }

    private void Start()
    {
        RenderInventory();
    }

    
    //render inventory to reflect players inventory
    public void RenderInventory()
    {
        //get the tool slots from inventory manager
        ItemData[] inventoryToolSlots = InventoryManager.Instance.tools;

        //get the inventory item slots from inventory manager
        ItemData[] inventoryItemSlots = InventoryManager.Instance.items;

        //render the tool section
        RenderInventoryPanel(inventoryToolSlots, toolSlots);

        //render the Item Section
        RenderInventoryPanel(inventoryItemSlots, itemSlots);
    }

    void RenderInventoryPanel(ItemData[] slots, InventorySlot[] uiSlots)
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            //display accordingly
            uiSlots[i].Display(slots[i]);
        }
    }

    public void ToggleInventoryPanel()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        RenderInventory();
    }

    //display item info on the item infobox
    public void DisplayItemInfo(ItemData data)
    {

        //If data is null, reset
        if(data == null)
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            return;
        }

        itemNameText.text = data.name;
        itemDescriptionText.text = data.description;
    }
}
