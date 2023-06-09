using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class MenuPhone : Singleton<MenuPhone>
{
    public Animator phoneAnim;
    public Transform screensHolder;
    public Button startButton;
    public Button deliveredButton;
    public Button redoButton;

    private void Start()
    {
        startButton.onClick.AddListener(StartHandler);
        deliveredButton.onClick.AddListener(DeliveredHandler);
        redoButton.onClick.AddListener(RedoHandler);
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
            screensHolder.GetChild(i).GetComponent<IScreen>().UpdateScreen();
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
        CameraManager.Instance.SetLive("olympusCam");
        DOVirtual.DelayedCall(2f, () =>
        GameManager.Instance.RestartLevel());
    }

    public void RedoHandler()
    {
        TogglePhone(false);
        CameraManager.Instance.SetLive("olympusCam");
        DOVirtual.DelayedCall(2f, () =>
        {
            GameManager.Instance.DecreaseLevelIndex();
            GameManager.Instance.RestartLevel();
        });
    }
}
