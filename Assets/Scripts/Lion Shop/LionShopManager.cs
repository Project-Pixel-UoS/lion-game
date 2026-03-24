using System.Collections.Generic;
using UnityEngine;

public class LionShopManager : MonoBehaviour
{

    [Header("Temp Currency")] public int currentCurrency = 0;
    public MoneyDisplay moneyDisplay;
    
    
    [Header("Lion Data")]
    public List<CharacterData> allLions; 

    [Header("UI References")]
    public Transform gridParent; 
    public GameObject shopCellPrefab;

    void Start()
    {
        moneyDisplay.UpdateCurrencyUI(currentCurrency);
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
        if (currentCurrency >= lion.price && !lion.isUnlocked)
        {
            currentCurrency -= lion.price;
            
            lion.isUnlocked = true;
            
            Debug.Log($"Unlocked: {lion.characterName}");
            moneyDisplay.UpdateCurrencyUI(currentCurrency);
            cell.UpdateUI();
        }

    }
}
