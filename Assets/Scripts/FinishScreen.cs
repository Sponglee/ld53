using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour, IScreen
{
    public TextMeshProUGUI bestTimeText;
    public TextMeshProUGUI currentTimeText;
    public TextMeshProUGUI orderText;

    public Image foodIcon;

    public void UpdateFoodIcon(Sprite aSprite)
    {
        foodIcon.sprite = aSprite;
    }
    public void UpdateBestTimer(float aValue)
    {
        bestTimeText.text = aValue.ToString();
    }

    public void UpdateCurrentTimer(float aValue)
    {
        currentTimeText.text = aValue.ToString();
    }
    public void UpdateOrderText(int aValue)
    {
        orderText.text = string.Format("ORDER {0}", aValue.ToString());
    }
    public void UpdateScreen()
    {
        UpdateBestTimer(GameManager.Instance.levelBestTime);
        UpdateCurrentTimer(GameManager.Instance.levelTime);
    }
}
