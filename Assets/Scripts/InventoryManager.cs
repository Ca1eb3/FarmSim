using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    private void Awake()
    {
        // If there is more than one instance, destroy the extra
        if(Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            // Set the static instance to this instance
            Instance = this;
        }
    }

    [Header("Tools")]
    // set of tools
    public ItemData[] tools = new ItemData[8];
    // tool in player's hand
    public ItemData equippedTool = null;

    [Header("Items")]
    // item slots
    public ItemData[] items = new ItemData[8];
    // item in player's hand
    public ItemData[] equippedItem = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
