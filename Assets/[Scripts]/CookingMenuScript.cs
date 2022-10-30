using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager.UI;
using UnityEngine;

public class CookingMenuScript : MonoBehaviour
{
    public List<Recipe> RecipeList;

    public GameObject cSS;
    public CharacterStatusScript _cScript;

    public GameObject fSS;
    public FoodStatsScript _fScript;

    public CookingSlot _cookingSlot1;
    public CookingSlot _cookingSlot2;
    public CookingSlot _cookingSlot3;

    public bool recipeOk = false;
    public bool getStats = false;

    public RecipeSlot _recipe;
    public Recipe _r;

    public Skills _s;

    public bool _reset = false;
    public bool _isSetRecipe;



    // Start is called before the first frame update
    void Start()
    {
        _cScript = cSS.GetComponent<CharacterStatusScript>();
        _fScript = fSS.GetComponent<FoodStatsScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_cookingSlot1.item != null && _cookingSlot2.item != null && _cookingSlot3.item != null) //when all three food types are added will generate the recipe
        {
            foreach (Recipe r in RecipeList)
            {
                if (_cookingSlot1.item.name == r.Carbs.name && _cookingSlot2.item.name == r.Meat.name &&
                _cookingSlot3.item.name == r.Salad.name) //if default recipe exists
                {
                    _r = r;
                    _s = r.Skill;
                    recipeOk = true;
                    _isSetRecipe = true;
                }
            }
            if (recipeOk == false) //else will modify the default one
            {
                _r = RecipeList[0];
                _r.name = _cookingSlot1.item.name + " with " + _cookingSlot2.item.name + " and " + _cookingSlot3.item.name + ".";
                _r.hpStat = _cookingSlot1.item.hpStat + _cookingSlot2.item.hpStat + _cookingSlot3.item.hpStat;
                _r.manaStat = _cookingSlot1.item.manaStat + _cookingSlot2.item.manaStat + _cookingSlot3.item.manaStat;
                _r.strStat = _cookingSlot1.item.strStat + _cookingSlot2.item.strStat + _cookingSlot3.item.strStat;
                _r.dexStat = _cookingSlot1.item.dexStat + _cookingSlot2.item.dexStat + _cookingSlot3.item.dexStat;
                _r.intStat = _cookingSlot1.item.intStat + _cookingSlot2.item.intStat + _cookingSlot3.item.intStat;
                _r.defStat = _cookingSlot1.item.defStat + _cookingSlot2.item.defStat + _cookingSlot3.item.defStat;
                _r.staStat = _cookingSlot1.item.staStat + _cookingSlot2.item.staStat + _cookingSlot3.item.staStat;
                _isSetRecipe = false; 
            }
            if (_reset == true) //updates stats once when an ingridient is changed
            {
                _fScript.statUpdate();
                _cScript.ResetSkills();
                _isSetRecipe = false;
                _reset = false;
            }
            _recipe.AddItem(_r); // adds the recipe to the recipe slot and will update the ui
            getStats = true;
        }
        else //else will reset the stats gains
        {
            _isSetRecipe = false;
            recipeOk = false;
            getStats = false;
            _r.hpStat = 0;
            _r.manaStat = 0;
            _r.strStat = 0;
            _r.dexStat = 0;
            _r.intStat = 0;
            _r.defStat = 0;
            _r.staStat = 0;
            _fScript.statUpdate();
            _cScript.ResetSkills();
            _recipe.RemoveItem();
        }

    }

    public void AddItem(ItemSlot _nItem) //used to add ingridients to the cooking menu, will after reset the ui to update stats
    {
        if (_nItem._type == FoodEnum.CARBS)
        {
            recipeOk = false;
            _cookingSlot1.AddItem(_nItem);
            _reset = true;
        }
        else if (_nItem._type == FoodEnum.MEAT)
        {
            recipeOk = false;
            _cookingSlot2.AddItem(_nItem);
            _reset = true;
        }
        else if (_nItem._type == FoodEnum.SALAD)
        {
            recipeOk = false;
            _cookingSlot3.AddItem(_nItem);
            _reset = true;
        }
    }

}
