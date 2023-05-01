using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public Slider slider;
    public Image fillBar;

    public Color activeColor;
    public Color rechargingColor;

    public void UpdareSliderValue(float aValue, bool aIsRecharging)
    {
        slider.value = aValue;

        fillBar.color = aIsRecharging ? rechargingColor : activeColor;
    }


}
