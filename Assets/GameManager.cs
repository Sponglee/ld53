using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public PlayerController playerController;
    public int levelIndex = 0;



    private void Start()
    {
        CameraManager.Instance.SetLive("startCam");
        MenuPhone.Instance.TogglePhone(true);
        MenuPhone.Instance.ToggleScreenByIndex(0);

    }

    public int GetLevelData()
    {
        levelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        return levelIndex;
    }

    public void StartGame()
    {
        CameraManager.Instance.SetLive("playCam");
        playerController.staminaController.InitializeStamina();
        playerController.staminaController.IsStaminaRecharging = true;

    }

    public void LevelComplete()
    {
        MenuPhone.Instance.TogglePhone(true);
        MenuPhone.Instance.ToggleScreenByIndex(1);
        levelIndex++;
        PlayerPrefs.SetInt("LevelIndex", levelIndex);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
