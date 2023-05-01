using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public PlayerController playerController;
    public int levelIndex = 0;

    public float levelTime = 0.0f;
    public float levelBestTime = 99999f;
    private bool isRunning = false;
    private void Start()
    {
        CameraManager.Instance.SetLive("startCam");
        MenuPhone.Instance.TogglePhone(true);
        MenuPhone.Instance.ToggleScreenByIndex(0);

        MainUI.Instance.ToggleLogo(true);

    }

    private IEnumerator UpdateTimer()
    {
        isRunning = true;

        while (isRunning)
        {
            yield return new WaitForSeconds(0.1f);
            levelTime += 0.1f;
            levelTime = Mathf.Round(levelTime * 100f) / 100f;
            MainUI.Instance.UpdateTimer(levelTime);
        }
    }

    public void StopTimer()
    {
        isRunning = false;
        StopAllCoroutines();
        levelBestTime = PlayerPrefs.GetFloat(string.Format("{0}LevelTime", levelIndex), 9999f);

        if (levelTime <= levelBestTime)
        {
            levelBestTime = levelTime;
            PlayerPrefs.SetFloat(string.Format("{0}LevelTime", levelIndex), levelTime);
        }

    }

    public int GetLevelData()
    {
        levelIndex = PlayerPrefs.GetInt("LevelIndex", 0);
        levelBestTime = PlayerPrefs.GetFloat(string.Format("{0}LevelTime", levelIndex), 9999f);
        return levelIndex;
    }

    public void StartGame()
    {
        CameraManager.Instance.SetLive("playCam");
        playerController.staminaController.InitializeStamina(() =>
        {
            MainUI.Instance.ToggleLogo(false);
            MainUI.Instance.ToggleTimer(true);
            StopAllCoroutines();
            StartCoroutine(UpdateTimer());
        });
        playerController.staminaController.IsStaminaRecharging = true;


    }

    public void IncreaseLevelIndex()
    {
        levelIndex++;
        levelIndex = levelIndex % StageController.Instance.levels.Length;

        PlayerPrefs.SetInt("LevelIndex", levelIndex);
    }
    public void DecreaseLevelIndex()
    {
        levelIndex--;
        if (levelIndex <= 0)
            levelIndex = 0;

        PlayerPrefs.SetInt("LevelIndex", levelIndex);
    }

    public void LevelComplete()
    {
        MenuPhone.Instance.TogglePhone(true);
        MenuPhone.Instance.ToggleScreenByIndex(1);

        IncreaseLevelIndex();

        MainUI.Instance.ToggleLogo(true);
        MainUI.Instance.ToggleTimer(false);
    }
    public void RestartLevel()
    {
        SceneManager.LoadScene("Main");
    }
}
