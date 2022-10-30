using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryManagerScript : MonoBehaviour
{
    public GameObject currentMenu;
    public TMP_Text _t;

    public void MenuChange(GameObject newMenu)
    {

    }

    public void MenuChange(int Type) //to change the inventory food type name when you change from one to another
    {

        switch (Type)
        {
            case 1:
                currentMenu.GetComponent<Inventory>().FoodType = FoodEnum.CARBS;
                _t.text = "CARBS";
                break;
            case 2:
                currentMenu.GetComponent<Inventory>().FoodType = FoodEnum.MEAT;
                _t.text = "MEAT";
                break;
            case 3:
                currentMenu.GetComponent<Inventory>().FoodType = FoodEnum.SALAD;
                _t.text = "SALAD";
                break;
        }

    }

}
