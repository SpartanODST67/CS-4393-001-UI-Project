using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class DetailsManager : MonoBehaviour
{
    [Header("Inventory Menu Elements")]
    [SerializeField] TextMeshProUGUI itemName;
    [SerializeField] TextMeshProUGUI itemQuantity;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] TextMeshProUGUI itemBuyPrice;
    [SerializeField] TextMeshProUGUI itemSellPrice;

    [Header("Relationships Menu Elements")]
    [SerializeField] TextMeshProUGUI characterName;
    [SerializeField] TextMeshProUGUI characterLevel;
    [SerializeField] TextMeshProUGUI characterDescription;
    [SerializeField] ProgressBar progressBar;
    [SerializeField] PopulateItemLists likesList;
    [SerializeField] PopulateItemLists dislikesList;

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

    public void SetCharacterName(string name)
    {
        characterName.text = name;
    }

    public void SetCharacterDescription(string description)
    {
        characterDescription.text = description;
    }

    public void SetCharacterLevel(string level)
    {
        characterLevel.text = level;
    }

    public void SetCharacterLevel(int level, int maxLevel)
    {
        if(level >= maxLevel)
        {
            characterLevel.text = "MAX";
            return;
        }
        characterLevel.text = level.ToString();
    }

    public void SetProgressBar(Vector2 progress)
    {
        progressBar.UpdateProgress((int) progress.x, (int) progress.y);
    }

    public void SetLikeItems(List<Item> likedItems)
    {
        likesList.PopulateList(likedItems);
    }

    public void SetDislikeItems(List<Item> likedItems)
    {
        dislikesList.PopulateList(likedItems);
    }
}
