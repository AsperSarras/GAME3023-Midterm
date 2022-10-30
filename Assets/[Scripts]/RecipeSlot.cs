using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class RecipeSlot : MonoBehaviour
{
    [SerializeField]
    private GameObject MainObject;
    private Inventory mOInventory;

    public Recipe _recipe = null;

    [SerializeField]
    private TMPro.TextMeshProUGUI descriptionText;
    [SerializeField]
    private TMPro.TextMeshProUGUI nameText;


    public Button _button;




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
        nameText.text = "";
        descriptionText.text = "";
        mOInventory = MainObject.GetComponent<Inventory>();
        UpdateGraphic();
    }

    //Change Icon and count
    void Update()
    {
        if (count > 0)
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
            _recipe = null;
            itemIcon.gameObject.SetActive(false);
            itemCountText.gameObject.SetActive(false);
        }
        else
        {
            //set sprite to the one from the item
            itemIcon.sprite = _recipe.icon;
            itemIcon.gameObject.SetActive(true);
            itemCountText.gameObject.SetActive(true);
            itemCountText.text = count.ToString();
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (_recipe != null)
        {
            descriptionText.text = _recipe.description;
            nameText.text = _recipe.name;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (_recipe != null)
        {
            descriptionText.text = "";
            nameText.text = "";
        }
    }

    public void AddItem(Recipe _r) //will add the item to the slot and update the ui
    {
        if (count < 1)
        {
            count=1;
        }
        if (_recipe != null)
        {
            _recipe = null;
        }

        _recipe = _r;
        _recipe.name = _r.name;
        _recipe.Skill = _r.Skill;

        nameText.text = _r.name;
        descriptionText.text = _r.description;
        UpdateGraphic();
    }
    public void RemoveItem() //will remove the item from the slot and update the ui
    {
        if (count > 0)
        {
            count = 0;
        }

        _recipe = null;
        itemIcon.gameObject.SetActive(false);
        itemCountText.gameObject.SetActive(false);
        nameText.text = "";
        descriptionText.text = "";
        UpdateGraphic();
    }


}
