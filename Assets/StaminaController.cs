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

    private bool _isInitialized = false;

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

    private void Start()
    {
        staminaUI.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (!_isInitialized) return;

        if (Stamina >= maxStamina)
        {
            Stamina = maxStamina;
            IsStaminaRecharging = false;
        }
        if (Stamina <= 0)
        {
            IsStaminaRecharging = true;
        }
    }

    public void InitializeStamina()
    {
        _isInitialized = true;
        staminaUI.gameObject.SetActive(true);
    }

    public void SpendStamina()
    {
        if (!_isInitialized) return;
        Stamina -= staminaBurnRate * Time.deltaTime;
        if (Stamina <= 0)
        {
            IsStaminaRecharging = true;
        }
    }
    public void SpendStamina(float aSpendAmount)
    {
        if (!_isInitialized) return;
        Stamina -= aSpendAmount;
        if (Stamina <= 0)
        {
            IsStaminaRecharging = true;
        }
    }

    public void RechargeStamina()
    {
        if (!_isInitialized) return;
        Stamina += staminaBurnRate * Time.deltaTime;

    }

    public void RechargeStamina(float aRechargeAmount)
    {
        if (!_isInitialized) return;
        Stamina += aRechargeAmount;
    }
}