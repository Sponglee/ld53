using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaUI : MonoBehaviour
{
    public Slider slider;


    public void UpdareSliderValue(float aValue)
    {
        slider.value = aValue;
    }
}
