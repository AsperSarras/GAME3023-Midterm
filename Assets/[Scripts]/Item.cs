using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Attribute which allows right click->Create
[CreateAssetMenu(fileName = "New Item", menuName = "Items/New Item")]
public class Item : ScriptableObject //Extending SO allows us to have an object which exists in the project, not in the scene
{
    public Sprite icon;
    public string description = "";
    public bool isConsumable = false;
    public FoodEnum type;

    //Stats
    public int hpStat;
    public int manaStat;
    public int strStat;
    public int dexStat;
    public int intStat;
    public int defStat;
    public int staStat;

    public void Use()
    {
        Debug.Log("Used item: " + name + " - " + description);
    }
}
