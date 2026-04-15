using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LionShopManager : MonoBehaviour
{
    [Header("Lion Data")]
    public List<CharacterData> allLions;

    [Header("UI References")]
    public Transform gridParent;
    public GameObject shopCellPrefab;
    public MoneyDisplay moneyDisplay;

    void Start()
    {
        moneyDisplay.UpdateCurrencyUI(PermanentCurrencyManager.Instance.CurrentPermanentCurrency);
        PopulateShop();
    }

    void PopulateShop()
    {
        foreach (CharacterData lion in allLions)
        {
            GameObject newCell = Instantiate(shopCellPrefab, gridParent);
            LionShopCell cellScript = newCell.GetComponent<LionShopCell>();
            cellScript.Initialize(lion, this);
        }
    }

    public void TryBuyLion(CharacterData lion, LionShopCell cell)
    {
        if (!lion.isUnlocked && PermanentCurrencyManager.Instance.SpendPermanentCurrency(lion.price))
        {
            lion.isUnlocked = true;

            Debug.Log($"Unlocked: {lion.characterName}");
            moneyDisplay.UpdateCurrencyUI(PermanentCurrencyManager.Instance.CurrentPermanentCurrency);
            cell.UpdateUI();
        }

    }
    public void ExitShop()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
