using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Land : MonoBehaviour, ITimeTracker
{
    public enum LandStatus
    {
        Soil, Farmland, Watered
    }

    public LandStatus landStatus;

    public Material soilMat, farmlandMat, wateredMat;
    new Renderer renderer;

    //The selection gameobject to enable when the player is selecting the land
    public GameObject select;

    GameTimeStamp timeWatered;

    // Start is called before the first frame update
    void Start()
    {
        //Get the renderer component
        renderer = GetComponent<Renderer>();

        //Set the land to soil by default
        SwitchLandStatus(LandStatus.Soil);

        //Deselect the land by default
        Select(false);

        TimeManager.Instance.RegisterTracker(this);
    }

    public void SwitchLandStatus(LandStatus statusToSwitch)
    {
        //Set land status accordingly
        landStatus = statusToSwitch;

        Material materialToSwitch = soilMat;

        //Decide what material to switch to
        switch (statusToSwitch)
        {
            case LandStatus.Soil:
                //Switch to the soil material
                materialToSwitch = soilMat;
                break;
            case LandStatus.Farmland:
                //Switch to farmland material 
                materialToSwitch = farmlandMat;
                break;

            case LandStatus.Watered:
                //Switch to watered material
                materialToSwitch = wateredMat;
                timeWatered = TimeManager.Instance.GetGameTimeStamp();
                break;

        }

        //Get the renderer to apply the changes
        renderer.material = materialToSwitch;
    }

    public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    //When the player presses the interact button while selecting this land
    public void Interact()
    {
        //Check the player's tool slot
        ItemData toolSlot = InventoryManager.Instance.equippedTool;

        //Try casting the itemdata in the toolslot as EquipmentData
        EquipmentData equipmentTool = toolSlot as EquipmentData;

        //Check if it is of type EquipmentData 
        if (equipmentTool != null)
        {
            //Get the tool type
            EquipmentData.ToolType toolType = equipmentTool.toolType;

            switch (toolType)
            {
                case EquipmentData.ToolType.Hoe:
                    SwitchLandStatus(LandStatus.Farmland);
                    break;
                case EquipmentData.ToolType.WateringCan:
                    SwitchLandStatus(LandStatus.Watered);
                    break;
            }


        }
    }
    public void ClockUpdate(GameTimeStamp timestamp)
    {
        if(landStatus == LandStatus.Watered) 
        {
            int hoursElapsed = GameTimeStamp.CompareTimeStamps(timeWatered, timestamp);

            if(hoursElapsed > 24)
            {
                SwitchLandStatus(LandStatus.Farmland);
            }
        }
    }
}