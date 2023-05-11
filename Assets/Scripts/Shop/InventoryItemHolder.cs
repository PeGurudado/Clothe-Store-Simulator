using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class InventoryItemHolder : ItemHolder
{
    [SerializeField] PlayerItemsManager playerItemsManager;

    public void EquipItemButton()
    {
        SetNameAndIcon();
        playerItemsManager.EquipNewItem(Item);
    }

}