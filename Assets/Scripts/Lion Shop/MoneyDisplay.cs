using TMPro;
using UnityEngine;

public class MoneyDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    public void UpdateCurrencyUI(int amount)
    {
        currencyText.text = $"{amount} G";
    }
}
