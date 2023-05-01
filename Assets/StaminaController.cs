using UnityEngine;

public class StaminaController : MonoBehaviour
{

    [Header("SETTINGS")]
    public float maxStamina = 10f;
    public float staminaBurnRate = 10f;
    public float staminaRechargeRate = 20f;

    [Space]
    [SerializeField] private float stamina = 0f;
    [SerializeField] private bool isStaminaRecharging = false;

    public StaminaUI staminaUI;

    public float Stamina
    {
        get => stamina;
        set
        {
            stamina = value;
            staminaUI.UpdareSliderValue(stamina / maxStamina);
        }
    }

    public bool IsStaminaRecharging
    {
        get => isStaminaRecharging; set
        {
            isStaminaRecharging = value;
        }
    }

    public void SpendStamina()
    {
        Stamina -= staminaBurnRate * Time.deltaTime;
        if (Stamina <= 0)
        {
            IsStaminaRecharging = true;
        }
    }
    public void SpendStamina(float aSpendAmount)
    {
        Stamina -= aSpendAmount;
        if (Stamina <= 0)
        {
            IsStaminaRecharging = true;
        }
    }

    public void RechargeStamina()
    {
        Stamina += staminaBurnRate * Time.deltaTime;
        if (Stamina >= maxStamina)
        {
            Stamina = maxStamina;
            IsStaminaRecharging = false;
        }
    }

    public void RechargeStamina(float aRechargeAmount)
    {
        Stamina += aRechargeAmount;
        if (Stamina >= maxStamina)
        {
            Stamina = maxStamina;
            IsStaminaRecharging = false;
        }
    }
}