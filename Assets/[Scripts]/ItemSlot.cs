using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

//Holds reference and count of items, manages their visibility in the Inventory panel
public class ItemSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject MainObject;
    private Inventory mOInventory;

    public Item item = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;


    public Button _button;

    public FoodEnum _type;



    [SerializeField]
    private int count = 0;
    public int Count
    {
        get { return count; }
        set
        {
            count = value;
            UpdateGraphic();
        }
    }

    [SerializeField]
    Image itemIcon;

    [SerializeField]
    TextMeshProUGUI itemCountText;

    // Start is called before the first frame update
    void Start()
    {
        mOInventory = MainObject.GetComponent<Inventory>();
        UpdateGraphic();
    }

    //Change Icon and count
    void Update()
    {
        if (item.type != mOInventory.FoodType && item.type != FoodEnum.NONE)
        {
            _button.interactable = false; 
        }
        else
        {
            _button.interactable = true;   
        }

        _type = item.type;


        UpdateGraphic();
    }

    void UpdateGraphic()
    {

        if (count < 1)
        {
            item = null;
            itemIcon.gameObject.SetActive(false);
            itemCountText.gameObject.SetActive(false);
        }
        else
        {
            //set sprite to the one from the item
            itemIcon.sprite = item.icon;
            itemIcon.gameObject.SetActive(true);
            itemCountText.gameObject.SetActive(true);
            itemCountText.text = count.ToString();
        }
    }

    public void UseItemInSlot()
    {
        if (CanUseItem())
        {
            //item.Use();
            if (item.isConsumable)
            {
                Count--;
                //mOInventory._cookingS.AddItem(this);
                mOInventory.AddItemIScript(this);
            }
        }
    }

    private bool CanUseItem()
    {
        return (item != null && count > 0);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (item != null)
        {
            descriptionText.text = item.description;
            nameText.text = item.name;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if(item != null)
        {
            descriptionText.text = "";
            nameText.text = "";
        }
    }
}
