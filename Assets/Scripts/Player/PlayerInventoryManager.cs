using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInventoryManager : MonoBehaviour
{
    [SerializeField] PlayerItemsManager playerItemsManager;
    [SerializeField] PlayerWallet playerWallet;
    [SerializeField] TextMeshProUGUI playerCashText;

    [SerializeField] InventoryItemHolder inventoryItemPrefab;
    [SerializeField] GameObject playerInventory;
    [SerializeField] RectTransform inventoryListContent;

    Dictionary<string, InventoryItemHolder> instantiatedInventoryItems = new Dictionary<string, InventoryItemHolder>();

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (playerInventory.activeInHierarchy)
            {
                playerInventory.SetActive(false);
                return;
            }
            //Opens Inventory
            UpdateInventoryUI();
            playerInventory.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Closes Inventorys
            playerInventory.SetActive(false);
        }
        
    }

    void UpdateInventoryUI()
    {
        foreach (var ownedItem in playerItemsManager.ownedItems)
        {
            if (instantiatedInventoryItems.ContainsKey(ownedItem.Value.Name)) continue;

            InventoryItemHolder newItem = Instantiate(inventoryItemPrefab, inventoryListContent.transform);
            newItem.gameObject.SetActive(true);
            newItem.Item = ownedItem.Value;
            instantiatedInventoryItems.Add(ownedItem.Value.Name, newItem);
        }
        playerCashText.text = "Cash: " + playerWallet.CurrentCash;
    }
}
