using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ItemHolder : MonoBehaviour
{
    [SerializeField] StoreManager storeManager;
    private Item item;

    public Item Item { get => item; set => item = value; }
    
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI nameText;
    [SerializeField] TextMeshProUGUI priceText;

    bool isBuyButton;
    public bool IsBuyButton { get => isBuyButton; set => isBuyButton = value; }

    // Start is called before the first frame update
    void Start()
    {
        iconImage.sprite = item.Icon;
        nameText.text = item.Name.ToString();
        priceText.text = item.Price.ToString();
    }

    public void InteractButton(){
        if(isBuyButton) BuyButton();
        else SellButton();
        
    }

    void BuyButton(){
        storeManager.Buy(this);
    }

    void SellButton(){
        storeManager.Sell(this);
    }
}