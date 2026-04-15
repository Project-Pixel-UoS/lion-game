using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 
using UnityEngine.EventSystems; 
public class LionShopCell : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    [SerializeField] private Image iconImage;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private Button purchaseButton;
    [SerializeField] private RectTransform parentContainer; 
    
    private CharacterData lionData;
    private LionShopManager shopManager;

    private Vector2 originalPos;
    public void Initialize(CharacterData charData, LionShopManager manager)
    {
        lionData = charData;
        shopManager = manager;

        iconImage.sprite = lionData.characterSprite;
        nameText.text = lionData.characterName;
        
        
        originalPos = parentContainer.anchoredPosition;
        UpdateUI();
    }

    
    
    public void UpdateUI()
    {
        if (lionData.isUnlocked)
        {
            priceText.text = "Unlocked";
            purchaseButton.interactable = false;
        }
        else
        {
            priceText.text = lionData.price.ToString() + " G";
            purchaseButton.interactable = true;
        }
    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        parentContainer.DOKill();
        parentContainer.DOAnchorPos(originalPos + new Vector2(0, 10f), 0.2f).SetEase(Ease.OutQuad);
        parentContainer.DOScale(1.05f, 0.2f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        parentContainer.DOKill();
        parentContainer.DOAnchorPos(originalPos, 0.2f).SetEase(Ease.OutQuad);
        parentContainer.DOScale(1f, 0.2f);
    }
    
    public void OnPurchaseClick()
    {
        shopManager.TryBuyLion(lionData, this);
    }
}
