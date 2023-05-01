using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPhone : Singleton<MenuPhone>
{
    public Animator phoneAnim;
    public Transform screensHolder;
    public Button startButton;
    public Button deliveredButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartHandler);
        deliveredButton.onClick.AddListener(DeliveredHandler);
    }


    public void TogglePhone(bool aToggle)
    {
        phoneAnim.SetBool("IsOut", aToggle);
    }

    public void ToggleScreenByIndex(int index)
    {
        for (int i = 0; i < screensHolder.childCount; i++)
        {
            screensHolder.GetChild(i).gameObject.SetActive(i == index);
        }
    }

    public void StartHandler()
    {
        GameManager.Instance.StartGame();
        TogglePhone(false);

    }

    public void DeliveredHandler()
    {
        TogglePhone(false);
        GameManager.Instance.RestartLevel();
    }
}
