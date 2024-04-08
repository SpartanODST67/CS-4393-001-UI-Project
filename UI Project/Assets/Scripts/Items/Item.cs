using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] int itemID;
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] int buyPrice;
    [SerializeField] int sellPrice;

    [Header("Inventory")]
    [SerializeField] Inventory inventory;

    [Header("For Display")]
    [SerializeField] GameObject myselfPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            inventory.AddItemQuantity(itemID);
            Destroy(gameObject); //Might be better to disable and enable the object instead of destorying and instantiating.
        }
    }

    public int GetItemID()
    {
        return itemID;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public string GetDescription()
    {
        return itemDescription;
    }

    public int GetBuyPrice()
    {
        return buyPrice;
    }

    public int GetSellPrice()
    {
        return sellPrice;
    }
}
