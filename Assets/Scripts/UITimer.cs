using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UITimer : MonoBehaviour
{
    public TextMeshProUGUI timerText;


    public void UpdateTimerText(float aSeconds)
    {
        timerText.text = aSeconds.ToString();
    }
}
