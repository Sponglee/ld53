using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StartScreen : MonoBehaviour, IScreen
{
    public TextMeshProUGUI orderText;
    public TextMeshProUGUI bestTimeText;

    public TextMeshProUGUI timerText;
    public Image foodIcon;

    public void UpdateFoodIcon(Sprite aSprite)
    {
        foodIcon.sprite = aSprite;
    }
    public void UpdateTimer(float aValue)
    {
        timerText.text = aValue.ToString();
    }

    public void UpdateOrderText(int aValue)
    {
        orderText.text = string.Format("ORDER {0}", aValue.ToString());
    }
    public void UpdateBestTimer(float aValue)
    {
        bestTimeText.gameObject.SetActive((aValue != 9999f));
        bestTimeText.text = aValue.ToString();
    }
    public void UpdateScreen()
    {
        UpdateTimer(GameManager.Instance.levelTime);
        UpdateBestTimer(GameManager.Instance.levelBestTime);

        UpdateOrderText(GameManager.Instance.levelIndex + 1);
    }
}
