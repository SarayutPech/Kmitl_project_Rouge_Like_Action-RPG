using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    public Slider slider;
    public Vector3 offset;

    public Color low;
    public Color high;
    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }       

    public void setHpBar( float hp, float MaxHp, bool hide)
    {
        slider.gameObject.SetActive(hide);
        slider.value = hp;
        slider.maxValue = MaxHp;

        slider.fillRect.GetComponent<Image>().color = Color.Lerp(low, high, slider.normalizedValue);
    }
}
