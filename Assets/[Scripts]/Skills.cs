using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill", menuName = "Skills/New Skill")]
public class Skills : ScriptableObject
{
    public SkillStatsEnum sType; //the stat that the skill will modify
    public int sValue;//the ammount 


}
