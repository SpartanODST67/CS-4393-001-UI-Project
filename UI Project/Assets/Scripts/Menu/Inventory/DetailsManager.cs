using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DetailsManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQuantity;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] TextMeshProUGUI itemBuyPrice;
    [SerializeField] TextMeshProUGUI itemSellPrice;

    public void Open()
    {
        gameObject.SetActive(true);
    }

    public void Close()
    {
        gameObject.SetActive(false);
    }

    public void SetItemName(string name)
    {
        itemName.text = name;
    }

    public void SetItemQuantity(string quantity)
    {
        itemQuantity.text = quantity;
    }

    public void SetItemQuantity(int quantity)
    {
        itemQuantity.text = "x" + quantity.ToString();
    }

    public void SetItemDescription(string description)
    {
        itemDescription.text = description;
    }

    public void SetItemBuyPrice(string buyPrice)
    {
        itemBuyPrice.text = "Buy For: $" + buyPrice;
    }

    public void SetItemSellPrice(string sellPrice)
    {
        itemSellPrice.text = "Sell For: $" + sellPrice;
    }

    public void SetItemBuyPrice(int buyPrice)
    {
        itemBuyPrice.text = "Buy For: " + buyPrice.ToString();
    }

    public void SetItemSellPrice(int sellPrice)
    {
        itemSellPrice.text = "Sell For: " + sellPrice.ToString();
    }
}
