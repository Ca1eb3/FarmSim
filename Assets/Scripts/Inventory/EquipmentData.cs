// Caleb Smith
// 10/17/2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Items/Equipment")]
public class EquipmentData : ItemData
{
    public enum ToolType
    {
        Axe
    }
    public ToolType toolType;

}
