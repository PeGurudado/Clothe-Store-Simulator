using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemsManager : MonoBehaviour
{
    public Dictionary<string, Item> ownedItems = new Dictionary<string, Item>();

    public Dictionary<Item.ItemType, Item> equippedItems = new Dictionary<Item.ItemType, Item>();
    private Dictionary<Item.ItemType, SpriteRenderer> itemRenderers = new Dictionary<Item.ItemType, SpriteRenderer>();

    [SerializeField] SpriteRenderer hatRenderer;
    [SerializeField] SpriteRenderer topRenderer;
    [SerializeField] SpriteRenderer bottomRenderer;
    [SerializeField] SpriteRenderer shoesRenderer;


    private void Start()
    {
        itemRenderers.Add(Item.ItemType.Hats, hatRenderer);
        itemRenderers.Add(Item.ItemType.Tops, topRenderer);
        itemRenderers.Add(Item.ItemType.Bottoms, bottomRenderer);
        itemRenderers.Add(Item.ItemType.Shoes, shoesRenderer);
    }

    public void EquipNewItem(Item equipItem)
    {
        if (equippedItems.ContainsKey(equipItem.Type) && equippedItems[equipItem.Type] == equipItem) //If already has item equipped then disequips
        {
            equippedItems[equipItem.Type] = null;
            itemRenderers[equipItem.Type].sprite = null;
        }
        else
        {
            equippedItems[equipItem.Type] = equipItem;
            itemRenderers[equipItem.Type].sprite = equipItem.OnCharacterSprite;
        }
    }
}
