using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class Item
{
    
    [SerializeField] private string name;
    [SerializeField] private float price;
    [SerializeField] private ItemType type;
    [SerializeField] private Sprite icon;
    [SerializeField] private Sprite onCharacterSprite;

    public ItemType Type { get => type; }
    public float Price { get => price;}
    public string Name { get => name;}
    public Sprite Icon { get => icon;}
    public Sprite OnCharacterSprite { get => onCharacterSprite; }

    public Item(string name, float price, ItemType type, Sprite icon ) {
        this.name = name; 
        this.price = price; 
        this.type = type; 
        this.icon = icon;
    }

    public enum ItemType: int
    {
        Tops, Bottoms, Shoes, Hats
    }
}