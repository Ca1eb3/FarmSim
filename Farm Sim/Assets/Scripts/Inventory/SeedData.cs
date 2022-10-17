// Caleb Smith
// 10/17/2022
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/Seed")]
public class SeedData : ItemData
{
    // time it takes for seed to mature
    public int daysToGrow;

    // type of crop the seed will yield
    public ItemData cropToYield;
}
