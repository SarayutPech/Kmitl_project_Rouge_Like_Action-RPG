using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EXP_Bar : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI exp_Text;
    public void SetEXP(int exp)
    {
        slider.value = exp;
    }

    public void SetMaxEXP(int maxExp)
    {
        slider.maxValue = maxExp;
    }

    public void setTextEXP(int exp , int maxExp)
    {
        exp_Text.text = exp.ToString() + " / " + maxExp.ToString();
    }
}
