using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ShopItemHolder : ItemHolder
{
    [SerializeField] StoreManager storeManager;
    [SerializeField] TextMeshProUGUI priceText;

    bool isBuyButton;
    public bool IsBuyButton { get => isBuyButton; set => isBuyButton = value; }

    private void Start()
    {
        Debug.Log("Shop item holder =>");
        SetNameAndIcon();
        priceText.text = Item.Price.ToString();
    }

    public void InteractButton(){
        if(IsBuyButton) BuyButton();
        else SellButton();
        
    }

    void BuyButton(){
        storeManager.Buy(this);
    }

    void SellButton(){
        storeManager.Sell(this);
    }
}