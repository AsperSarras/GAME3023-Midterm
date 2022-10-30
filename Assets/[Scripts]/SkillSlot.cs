using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillSlot : MonoBehaviour
{
    public Skills _skill;
    public TMP_Text _text;

    public bool hasSkill = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(hasSkill==true) //will modify the text if the slot has a skill
        {
            _text.text = _skill.name;
        }
        else
        {
            _text.text = "";
        }
    }

    public void ResetSkills() //used to remove the skill from the slot
    {
        _skill = null;
        hasSkill = false;
    }
}
