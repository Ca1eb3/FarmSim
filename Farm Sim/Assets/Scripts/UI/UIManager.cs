using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("Inventory System")]
    //the inventory panel
    public GameObject inventoryPanel;

    //the tool slot UIs
    public InventorySlot[] toolSlots;

    //the item slot UIs
    public InventorySlot[] itemSlots;

    //Item info box
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


    //render inventory screen to show player inventory
    public void RenderInventory()
    {
        //get inventory tool slots from item manager
        ItemData[] inventoryToolSlots = InventoryManager.Instance.tools;

        //Get the inventory item slots from Inventory Manager
        ItemData[] inventoryItemSlots = InventoryManager.Instance.items;

        //render the tool section
        RenderInventoryPanel(inventoryToolSlots, toolSlots);

        //render the item section
        RenderInventoryPanel(inventoryItemSlots, itemSlots);
    }

    //iterate through a slot in a section and display them in the UI
    void RenderInventoryPanel(ItemData[] slots, InventorySlot[] uiSlots)
    {
        for (int i = 0; i < uiSlots.Length; i++)
        {
            //display them accordingly
            uiSlots[i].Display(slots[i]);
        }
    }

    public void ToggleInventoryPanel()
    {
        //if the panel iss open, it will close. If it is closed, it will open
        inventoryPanel.SetActive(inventoryPanel.activeSelf);

        RenderInventory();
    }

    //Display item info on the item infobox
    public void DisplayItemInfo(ItemData data)
    {
        //if the data is null then reset it
        if (data == null)
        {
            itemNameText.text = "";
            itemDescriptionText.text = "";
            return;
        }
        itemNameText.text = data.name;
        itemDescriptionText.text = data.description;
    }

}
