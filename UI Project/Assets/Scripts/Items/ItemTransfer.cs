using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class ItemTransfer : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    private Conversation targetCharacter;
    private int itemID = 0;
    private int itemQuantity = 1;
    private int moneyAmount = 1;

    public void SetTargetCharacter(Conversation targetCharacter)
    {
        this.targetCharacter = targetCharacter;
    }

    public void SetItemID(int itemID)
    {
        this.itemID = itemID;
    }

    public void SetItemQuantity(int itemQuantity)
    {
        this.itemQuantity = itemQuantity;
    }

    public void SetMoneyAmount(int moneyAmount)
    {
        this.moneyAmount = moneyAmount;
    }

    public void GiveItem()
    {
        inventory.RemoveItemQuantity(itemID);
        targetCharacter.ReceiveGift(itemID);
    }

    public void GiveItem(int itemID)
    {
        inventory.RemoveItemQuantity(itemID);
        targetCharacter.ReceiveGift(itemID);
    }

    public void RemoveItem()
    {
        inventory.RemoveItemQuantity(itemID, itemQuantity);
    }

    public void RemoveItem(int itemID)
    {
        inventory.RemoveItemQuantity(itemID, itemQuantity);
    }

    public void RemoveItem(int itemID, int itemQuantity)
    {
        inventory.RemoveItemQuantity(itemID, itemQuantity);
    }

    public void AddItem()
    {
        inventory.AddItemQuantity(itemID);
    }

    public void AddItem(int itemID)
    {
        inventory.AddItemQuantity(itemID);
    }

    public void AddItem(int itemID, int itemQuantity)
    {
        inventory.AddItemQuantity(itemID, itemQuantity);
    }

    public void AddMoney()
    {
        inventory.wallet += moneyAmount;
    }

    public void AddMoney(int moneyAmount)
    {
        inventory.wallet += moneyAmount;
    }

    public void RemoveMoney()
    {
        inventory.wallet -= moneyAmount;
    }

    public void RemoveMoney(int moneyAmount)
    {
        inventory.wallet -= moneyAmount;
    }
}
