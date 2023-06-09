using UnityEngine;
using TMPro;

public class StoreManager : MonoBehaviour
{
    [SerializeField] PlayerWallet playerWallet; 
    [SerializeField] PlayerItemsManager playerItemsManager;

    [SerializeField] ShopItemHolder itemPrefab;

    [SerializeField] Item[] itemsShopList;     

    [Header("UI")]
    [SerializeField] RectTransform buyListContent;
    [SerializeField] TextMeshProUGUI playerMoney;
    [SerializeField] RectTransform sellListContent;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Item shopItem in itemsShopList)
        {
            ShopItemHolder newItem = Instantiate(itemPrefab, buyListContent.transform);
            newItem.IsBuyButton = true;  //Sets the button to call Buy 
            newItem.gameObject.SetActive(true);
            newItem.Item = shopItem;
        }

        foreach (var owneditem in playerItemsManager.ownedItems)
        {
            ShopItemHolder newItem = Instantiate(itemPrefab, sellListContent.transform);
            newItem.IsBuyButton = false;  //Sets the button to call Sell 
            newItem.gameObject.SetActive(true);
            newItem.Item = owneditem.Value;
        }

        UpdatePlayerMoneyUI();        
    }


    bool HasEnoughMoney(float moneyCost){
        if(playerWallet.CurrentCash > moneyCost){
            return true;
        }

        return false;
    }

    public bool Buy(ShopItemHolder itemHolder){        
        if(!HasEnoughMoney(itemHolder.Item.Price)) return false;

        playerWallet.CurrentCash -= itemHolder.Item.Price; //Reduces Player's money
        playerItemsManager.ownedItems.Add(itemHolder.Item.Name, itemHolder.Item); //Adds new item to players owned items based on item name

        itemHolder.transform.SetParent(sellListContent.transform); //Sends item frame to Sell List
        itemHolder.IsBuyButton = false; //Sets the button to call Sell
        UpdatePlayerMoneyUI();
        Invoke("AdjustSellListUI", 0.05f); //Waits horizontal layout UI to set list position
        return true;
    }

    public void Sell(ShopItemHolder itemHolder){
        playerWallet.CurrentCash += (playerItemsManager.ownedItems[itemHolder.Item.Name].Price); //Adds item value to player wallet
        playerItemsManager.ownedItems.Remove(itemHolder.Item.Name); //Remove item from player item's list

        //Checks if player was with that item equipped
        if(playerItemsManager.equippedItems.ContainsKey(itemHolder.Item.Type) && playerItemsManager.equippedItems[itemHolder.Item.Type] == itemHolder.Item)
        {
            playerItemsManager.EquipNewItem(itemHolder.Item); //If has, calls equip function again to desequip
        }

        itemHolder.transform.SetParent(buyListContent.transform); //Sends item frame to Buy List
        itemHolder.IsBuyButton = true; //Sets button to call Buy
        UpdatePlayerMoneyUI();
        Invoke("AdjustBuyListUI", 0.05f); //Waits horizontal layout UI to set list position
    }

    void UpdatePlayerMoneyUI()
    {
        playerMoney.text = "Cash: "+ playerWallet.CurrentCash;
    }

    void AdjustSellListUI()
    {
        sellListContent.position = new Vector2(-sellListContent.sizeDelta.x*2, sellListContent.position.y); //Puts horizontal content slided just at the very right
    }

    void AdjustBuyListUI()
    {
        buyListContent.position = new Vector2(buyListContent.sizeDelta.x*2, buyListContent.position.y); //Puts horizontal content slided just at the very left
    }

}