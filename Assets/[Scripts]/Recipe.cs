using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipe/New Recipe")]
public class Recipe : ScriptableObject
{
    public Sprite icon;
    public string description = "";
    public bool isConsumable = false; //just to make not clickable, could delete

    public Item Carbs;
    public Item Meat;
    public Item Salad;

    public Skills Skill;

    //Stats
    public int hpStat;
    public int manaStat;
    public int strStat;
    public int dexStat;
    public int intStat;
    public int defStat;
    public int staStat;
}
