using UnityEngine;
using System;
using UnityEngine.UI;
using TMPro;

public class ItemHolder : MonoBehaviour
{
    private Item item;

    public Item Item { get => item; set => item = value; }
    
    [SerializeField] Image iconImage;
    [SerializeField] TextMeshProUGUI nameText;

    // Start is called before the first frame update
    void Start()
    {
        SetNameAndIcon();
    }

    protected void SetNameAndIcon()
    {
        iconImage.sprite = item.Icon;
        nameText.text = item.Name.ToString();
    }
}