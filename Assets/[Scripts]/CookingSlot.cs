using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookingSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject MainObject;
    private Inventory mOInventory;

    public ItemSlot _nItemSlot;

    public Item item = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;


    public Button _button;

    public bool hasItem = false;

    //public bool skillReset = false;



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
        //mOInventory = MainObject.GetComponent<Inventory>();
        UpdateGraphic();
    }

    //Change Icon and count
    void Update()
    {
        if (count>0)
        {
            _button.interactable = true;
        }
        else
        {
            _button.interactable = false;
        }

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
                _nItemSlot.Count++;
                hasItem = false;
                item = null;
                _nItemSlot = null;
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
        if (item != null)
        {
            descriptionText.text = "";
            nameText.text = "";
        }
    }

    public void AddItem(ItemSlot _nItem)
    {
        if(count<1)
        {
            count++;
        }
        if(_nItemSlot != null)
        {
            _nItemSlot.Count++;
            _nItemSlot = null;
        }

        _nItemSlot = _nItem;
        item = _nItemSlot.item;
        hasItem = true;
        UpdateGraphic();
    }
}
