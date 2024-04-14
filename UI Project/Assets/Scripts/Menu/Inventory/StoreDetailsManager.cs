using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoreDetailsManager : MonoBehaviour
{
    [Header("Inventory Menu Elements")]
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQuantity;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] TextMeshProUGUI itemBuyPrice;
    [SerializeField] TextMeshProUGUI itemSellPrice;
    [SerializeField] Button buyButton;
    [SerializeField] TransactionButton buyButtonScript;
    [SerializeField] Button sellButton;
    [SerializeField] TransactionButton sellButtonScript;
    [SerializeField] DisplayEmptyActionText actions;
    [SerializeField] GameObject fullInventory;
    private ItemTransfer itemTransfer;

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
        itemBuyPrice.text = "Buy For: $" + buyPrice.ToString();
    }

    public void SetItemSellPrice(int sellPrice)
    {
        itemSellPrice.text = "Sell For: $" + sellPrice.ToString();
    }

    public void SetItemTransfer(ItemTransfer itemTransfer)
    {
        this.itemTransfer = itemTransfer;
    } 

    public void ActivateBuyButton(int moneyAmount)
    {
        buyButtonScript.SetMoneyAmount(moneyAmount);
        buyButton.onClick.RemoveAllListeners();
        buyButton.onClick.AddListener(() =>
        {
            itemTransfer.SetMoneyAmount(buyButtonScript.GetMoneyAmount());
            itemTransfer.AddItem();
            itemTransfer.RemoveMoney();
            gameObject.SetActive(false);
            fullInventory.SetActive(false);
            fullInventory.SetActive(true);
        });
        buyButtonScript.gameObject.SetActive(true);
    }

    public void ActivateSellButton(int moneyAmount)
    {
        sellButtonScript.SetMoneyAmount(moneyAmount);
        sellButton.onClick.RemoveAllListeners();
        sellButton.onClick.AddListener(() =>
        {
            itemTransfer.SetMoneyAmount(sellButtonScript.GetMoneyAmount());
            itemTransfer.AddMoney();
            itemTransfer.RemoveItem();
            gameObject.SetActive(false);
            fullInventory.SetActive(false);
            fullInventory.SetActive(true);
        });
        sellButtonScript.gameObject.SetActive(true);
    }

    public void DisactivateBuyButton()
    {
        buyButtonScript.gameObject.SetActive(false);
    }

    public void DisactivateSellButton()
    {
        sellButtonScript.gameObject.SetActive(false);
    }

    public void CheckForEmptyActions()
    {
        actions.CheckForEmptyActions();
    }
}
