using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    ItemData itemToDisplay;

    public Image itemDisplayImage;

    public void Display(ItemData itemToDisplay)
    {
        //check if there is an item to display
        if(itemToDisplay != null)
        {
            //switch the thumbnail over
            itemDisplayImage.sprite = itemToDisplay.thumbnail;
            this.itemToDisplay = itemToDisplay;
            itemDisplayImage.gameObject.SetActive(true);
            return;
        }

        itemDisplayImage.gameObject.SetActive(false);
    }

   
    //display item info when player mouses over an item
    public void OnPointerEnter(PointerEventData eventData)
    {
        UIManager.Instance.DisplayItemInfo(itemToDisplay);
    }

    //reset item info when player mouses over an item
    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.Instance.DisplayItemInfo(null);
    }
}
