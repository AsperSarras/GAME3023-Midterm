using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    List<ItemSlot> itemSlots = new List<ItemSlot>();

    [SerializeField]
    GameObject inventoryPanel;

    [SerializeField]
    public FoodEnum FoodType;

    public CookingMenuScript _cookingS;

    void Start()
    {
        //Read all itemSlots as children of inventory panel
        itemSlots = new List<ItemSlot>(
            inventoryPanel.transform.GetComponentsInChildren<ItemSlot>()
            );
    }

    public void AddItemIScript(ItemSlot _iSlot)
    {
        _cookingS.AddItem(_iSlot);
    }

}
