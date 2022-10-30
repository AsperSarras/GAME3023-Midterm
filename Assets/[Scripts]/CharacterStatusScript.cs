using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using TMPro;
using UnityEngine;

public class CharacterStatusScript : MonoBehaviour
{
    //Script in charge of modifying the character stats
    public int i = 0;

    public GameObject _fsS;
    public FoodStatsScript _fScript;

    public GameObject _cmS;
    public CookingMenuScript _cScript;

    public List<SkillSlot> ssList; //list of skills slot 4 by default
    public List<Skills> sList; //the list with the skills available, must add the skill to the list from unity in order to use it
    public SkillSlot rSkill; //slot for the premade recipe skill


    /*to add another stat just add the stat with the base
     *and if it is a displayed stat make a base and the reference to the button along with the block bool
    */
    //this are the stats displayed
    public TMP_Text _hpT;
    public int _hpBase = 10;
    public int _hp;
    public TMP_Text _manaT;
    public int _manaBase = 10;
    public int _mana;
    public TMP_Text _strT;
    public int _strBase = 1;
    public int _str;
    public TMP_Text _dexT;
    public int _dexBase = 1;
    public int _dex;
    public TMP_Text _intT;
    public int _intBase = 1;
    public int _int;    
    public TMP_Text _defT;
    public int _defBase = 1;
    public int _def;
    public TMP_Text _staT;
    public int _staBase = 1;
    public int _sta;
    //others unseen stats
    public int _atk = 1;
    public int _dmgr = 1;
    public int _eva = 1;
    public int _hpreg = 1;
    public int _mgcd = 1;
    public int _manareg = 1;
    public int _star = 1;
    public int _extrad = 0;
    public int _refl = 0;
    public int _JumpPower = 1;

    public bool showStats = false; // used to know when the recipe is ready or not, if this is false stast wont be updated on screen and will return to the base value

    //for displayed stats to avoid adding per update
    public bool _hpSBlock = false;
    public bool _manaSBlock = false;
    public bool _strSBlock = false;
    public bool _dexSBlock = false;
    public bool _intSBlock = false;
    public bool _defSBlock = false;
    public bool _staSBlock = false;

    void Start()
    {
        _fScript = _fsS.GetComponent<FoodStatsScript>();
        _cScript = _cmS.GetComponent<CookingMenuScript>();
        
    }

    // Update is called once per frame
    void Update()
    {
        showStats = _fScript._stat;

        UpdateSkills();

        if (showStats == true) // add stats and modify display
        {
            _hp = _hpBase + _fScript._hpStat;
            _mana = _manaBase + _fScript._manaStat;
            _str = _strBase + _fScript._strStat;
            _dex = _dexBase + _fScript._dexStat; 
            _int = _intBase + _fScript._intStat;
            _def = _defBase + _fScript._defStat;
            _sta = _staBase + _fScript._staStat;

            _hpT.text = _hp.ToString() + "/" + _hp.ToString();
            _manaT.text = _mana.ToString() + "/" + _mana.ToString();
            _strT.text = _str.ToString();
            _dexT.text = _dex.ToString();
            _intT.text = _int.ToString();
            _defT.text = _def.ToString();
            _staT.text = _sta.ToString();
        }
        else // return to base
        {
            _hpT.text = _hpBase.ToString()+"/"+_hpBase.ToString();
            _manaT.text = _manaBase.ToString() + "/"+_manaBase.ToString();
            _strT.text = _strBase.ToString();
            _dexT.text = _dexBase.ToString();
            _intT.text = _intBase.ToString();
            _defT.text = _defBase.ToString();
            _staT.text = _staBase.ToString();
            ResetSkills();
        }
    }
    /*
     * this are for skills default stats needed to get a skill are 10/8/6 except for recipes with skills
     * to add a skill with requirements or change it just copy the format code and modify it
     * if(block = false)
     * {
     * if(requirement)
     * {
     * skillslot[i].skill = listofskills[the position of the desired skill]
     * skillslot[i].hasskill=true
     * block=true
     * i++
     * }
     * }
     * 
     * 
    */
    public void UpdateSkills() 
    {
        if (_hpSBlock == false)//hp
        {
            if (_fScript._hpStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[0];
                ssList[i].hasSkill = true;
                _hpSBlock = true;
                i++;
            }
            else if (_fScript._hpStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[1];
                ssList[i].hasSkill = true;
                _hpSBlock = true;
                i++;
            }
            else if (_fScript._hpStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[2];
                ssList[i].hasSkill = true;
                _hpSBlock = true;
                i++;
            }
        }
        if (_manaSBlock == false)//mana
        {
            if (_fScript._manaStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[3];
                ssList[i].hasSkill = true;
                _manaSBlock = true;
                i++;
            }
            else if (_fScript._manaStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[4];
                ssList[i].hasSkill = true;
                _manaSBlock = true;
                i++;
            }
            else if (_fScript._manaStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[5];
                ssList[i].hasSkill = true;
                _manaSBlock = true;
                i++;
            }
        }
        if (_strSBlock == false)
        {
            if (_fScript._strStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[6];
                ssList[i].hasSkill = true;
                _strSBlock = true;
                i++;
            }
            else if (_fScript._strStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[7];
                ssList[i].hasSkill = true;
                _strSBlock = true;
                i++;
            }
            else if (_fScript._strStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[8];
                ssList[i].hasSkill = true;
                _strSBlock = true;
                i++;
            }
        }
        if (_dexSBlock == false)
        {
            if (_fScript._dexStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[9];
                ssList[i].hasSkill = true;
                _dexSBlock = true;
                i++;
            }
            else if (_fScript._dexStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[10];
                ssList[i].hasSkill = true;
                _dexSBlock = true;
                i++;
            }
            else if (_fScript._dexStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[11];
                ssList[i].hasSkill = true;
                _dexSBlock = true;
                i++;
            }
        }
        if (_intSBlock == false)
        {
            if (_fScript._intStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[12];
                ssList[i].hasSkill = true;
                _intSBlock = true;
                i++;
            }
            else if (_fScript._intStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[13];
                ssList[i].hasSkill = true;
                _intSBlock = true;
                i++;
            }
            else if (_fScript._intStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[14];
                ssList[i].hasSkill = true;
                _intSBlock = true;
                i++;
            }
        }
        if (_defSBlock == false)
        {
            if (_fScript._defStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[15];
                ssList[i].hasSkill = true;
                _defSBlock = true;
                i++;
            }
            else if (_fScript._defStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[16];
                ssList[i].hasSkill = true;
                _defSBlock = true;
                i++;
            }
            else if (_fScript._defStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[17];
                ssList[i].hasSkill = true;
                _defSBlock = true;
                i++;
            }
        }
        if (_staSBlock == false)
        {
            if (_fScript._staStat >= 10)
            {
                Debug.Log("10+");
                ssList[i]._skill = sList[18];
                ssList[i].hasSkill = true;
                _staSBlock = true;
                i++;
            }
            else if (_fScript._staStat >= 8)
            {
                Debug.Log("8+");
                ssList[i]._skill = sList[19];
                ssList[i].hasSkill = true;
                _staSBlock = true;
                i++;
            }
            else if (_fScript._staStat >= 4)
            {
                Debug.Log("4+");
                ssList[i]._skill = sList[20];
                ssList[i].hasSkill = true;
                _staSBlock = true;
                i++;
            }
        }

        //To add the skill from the premade recipe
        if (_cScript._isSetRecipe == true)
        {
            rSkill._skill = _cScript._s;
            rSkill.hasSkill = true;
        }
        else
        {
            rSkill._skill = null;
            rSkill.hasSkill = false; ;
        }

    }

    //Adds the stats from the skills to the character and is supposed to finish the menu and go back to game mode with the updated stats
    public void SkillsValuesAdd()
    {
        if(showStats == true)
        {
            foreach (SkillSlot ss in ssList)
            {
                int i = ((int)ss._skill.sType);
                switch (i) //each case is a skill value from the SkillStatEnum, if you want to add new stats that skills could modify you must add it to the enum and add it here after that
                {
                    case 0:
                        _hp = _hp + ss._skill.sValue;
                        break;
                    case 1:
                        _mana = _mana + ss._skill.sValue;
                        break;
                    case 2:
                        _str = _str + ss._skill.sValue;
                        break;
                    case 3:
                        _dex = _dex + ss._skill.sValue;
                        break;
                    case 4:
                        _int = _int + ss._skill.sValue;
                        break;
                    case 5:
                        _def = _def + ss._skill.sValue;
                        break;
                    case 6:
                        _sta = _sta + ss._skill.sValue;
                        break;
                    case 7:
                        _atk = _atk + ss._skill.sValue;
                        break;
                    case 8:
                        _dmgr = _dmgr + ss._skill.sValue;
                        break;
                    case 9:
                        _eva = _eva + ss._skill.sValue;
                        break;
                    case 10:
                        _hpreg = _hpreg + ss._skill.sValue;
                        break;
                    case 11:
                        _mgcd = _mgcd + ss._skill.sValue;
                        break;
                    case 12:
                        _manareg = _manareg + ss._skill.sValue;
                        break;
                    case 13:
                        _star = _star + ss._skill.sValue;
                        break;
                    case 14:
                        _extrad = _extrad + ss._skill.sValue;
                        break;
                    case 15:
                        _refl = _refl + ss._skill.sValue;
                        break;
                }
            }

            if (_cScript._isSetRecipe == true)
            {
                int i = ((int)rSkill._skill.sType);
                switch (i) //each case is a skill value from the SkillStatEnum, if you want to add new stats that skills could modify you must add it to the enum and add it here after that
                {
                    case 0:
                        _hp = _hp + rSkill._skill.sValue;
                        break;
                    case 1:
                        _mana = _mana + rSkill._skill.sValue;
                        break;
                    case 2:
                        _str = _str + rSkill._skill.sValue;
                        break;
                    case 3:
                        _dex = _dex + rSkill._skill.sValue;
                        break;
                    case 4:
                        _int = _int + rSkill._skill.sValue;
                        break;
                    case 5:
                        _def = _def + rSkill._skill.sValue;
                        break;
                    case 6:
                        _sta = _sta + rSkill._skill.sValue;
                        break;
                    case 7:
                        _atk = _atk + rSkill._skill.sValue;
                        break;
                    case 8:
                        _dmgr = _dmgr + rSkill._skill.sValue;
                        break;
                    case 9:
                        _eva = _eva + rSkill._skill.sValue;
                        break;
                    case 10:
                        _hpreg = _hpreg + rSkill._skill.sValue;
                        break;
                    case 11:
                        _mgcd = _mgcd + rSkill._skill.sValue;
                        break;
                    case 12:
                        _manareg = _manareg + rSkill._skill.sValue;
                        break;
                    case 13:
                        _star = _star + rSkill._skill.sValue;
                        break;
                    case 14:
                        _extrad = _extrad + rSkill._skill.sValue;
                        break;
                    case 15:
                        _refl = _refl + rSkill._skill.sValue;
                        break;
                }
            }

        }    
    }

    public void Cancel() //Cancell Stat Changes and supposed to go back to the game
    {
        _hp = _hpBase;
        _mana = _manaBase;
        _str = _strBase;
        _dex = _dexBase;
        _int = _intBase;
        _sta = _staBase;
        _def = _defBase;
        _atk = 1;
        _dmgr = 1;
        _eva = 1;
        _hpreg = 1;
        _mgcd = 1;
        _manareg = 1;
        _star = 1;
        _extrad = 0;
        _refl = 0;
    }

    public void ResetSkills() //after recipes are modify you call this to update stats
    {
        foreach (SkillSlot ss in ssList)
        {
            ss.ResetSkills();
        }
        rSkill._skill = null;
        Debug.Log("Reset");
        _hpSBlock = false;
        _manaSBlock = false;
        _strSBlock = false;
        _dexSBlock = false;
        _intSBlock = false;
        _defSBlock = false;
        _staSBlock = false;
        i = 0;
        UpdateSkills();
    }
}
