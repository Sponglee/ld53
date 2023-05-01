using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainUI : Singleton<MainUI>
{
    public TitleController titleController;
    public Transform uiContainer;
    public UITimer uITimer;


    public void UpdateTimer(float aValue)
    {
        uITimer.UpdateTimerText(aValue);
    }

    public void ToggleLogo(bool aToggle)
    {
        titleController.ToggleLogo(aToggle);
    }

    public void ToggleTimer(bool aToggle)
    {
        uITimer.gameObject.SetActive(aToggle);
    }
}
