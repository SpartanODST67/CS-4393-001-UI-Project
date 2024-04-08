using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTransfer : MonoBehaviour
{
    [SerializeField] Inventory inventory;
    private Conversation targetCharacter;
    private int itemID = 0;
    private int itemQuantity = 1;

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

    public void GiveItem()
    {
        inventory.RemoveItemQuantity(itemID);
        targetCharacter.ReceiveGift(itemID);
    }

    public void RemoveItem()
    {
        inventory.RemoveItemQuantity(itemID, itemQuantity);
    }
}
