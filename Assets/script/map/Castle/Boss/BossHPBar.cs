using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPBar : MonoBehaviour
{
    public Slider slider;
    public Color low;
    public Color high;
    // Update is called once per frame
    public void setHpBar(float hp, float MaxHp)
    {
        slider.value = hp;
        slider.maxValue = MaxHp;
        slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
