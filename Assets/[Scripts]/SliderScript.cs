using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{
    public int _Stat;
    public TMP_Text _T;
    public Slider _slider;


    void Start()
    {
    }

    void Update() //modify the slide number value
    {
        _T.text = _Stat.ToString();
        _slider.value = _Stat;
    }
}
