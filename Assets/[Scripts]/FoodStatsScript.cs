using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodStatsScript : MonoBehaviour
{
    public GameObject CookingMenu;
    public CookingMenuScript _cmS;

    public GameObject HpSlide;
    public SliderScript _hpS;

    public GameObject ManaSlide;
    public SliderScript _manaS;

    public GameObject StrSlide;
    public SliderScript _strS;

    public GameObject DexSlide;
    public SliderScript _dexS;

    public GameObject IntSlide;
    public SliderScript _intS;

    public GameObject DefSlide;
    public SliderScript _defS;

    public GameObject StaSlide;
    public SliderScript _staS;

    public int _hpStat;
    public int _manaStat;
    public int _strStat;
    public int _dexStat;
    public int _intStat;
    public int _defStat;
    public int _staStat;

    public bool _stat = false;


    void Start()
    {
        _cmS = CookingMenu.GetComponent<CookingMenuScript>();
        _hpS = HpSlide.GetComponent<SliderScript>();
        _manaS = ManaSlide.GetComponent<SliderScript>();
        _strS = StrSlide.GetComponent<SliderScript>();
        _dexS = DexSlide.GetComponent<SliderScript>();
        _intS = IntSlide.GetComponent<SliderScript>();
        _defS = DefSlide.GetComponent<SliderScript>();
        _staS = StaSlide.GetComponent<SliderScript>();
    }

    void Update()
    {
        statUpdate();
    }

    public void statUpdate() //will update the values passed to the character status script and will update the sliders
    {
        _hpStat = _cmS._r.hpStat;
        _hpS._Stat = _hpStat;

        _manaStat = _cmS._r.manaStat;
        _manaS._Stat = _manaStat;

        _strStat = _cmS._r.strStat;
        _strS._Stat = _strStat;

        _dexStat = _cmS._r.dexStat;
        _dexS._Stat = _dexStat;

        _intStat = _cmS._r.intStat;
        _intS._Stat = _intStat;

        _defStat = _cmS._r.defStat;
        _defS._Stat = _defStat;

        _staStat = _cmS._r.staStat;
        _staS._Stat = _staStat;

        _stat = _cmS.getStats;
    }

}
