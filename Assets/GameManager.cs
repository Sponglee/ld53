using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    private void Start()
    {
        CameraManager.Instance.SetLive("startCam");
        MenuPhone.Instance.TogglePhone(true);
        MenuPhone.Instance.ToggleScreenByIndex(0);
    }


    public void StartGame()
    {
        CameraManager.Instance.SetLive("playCam");

    }

    public void LevelComplete()
    {
        MenuPhone.Instance.TogglePhone(true);
        MenuPhone.Instance.ToggleScreenByIndex(1);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
