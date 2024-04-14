using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopulateStoreItems : MonoBehaviour
{
    [Header("Background Systems")]
    [SerializeField] Inventory inventory;
    [SerializeField] ItemTransfer itemTransfer;
    [Header("Displayed Systems")]
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] StoreDetailsManager detailsPage;
    [SerializeField] GameObject emptyNotification;
    [SerializeField] TextMeshProUGUI walletAmount;

    private void OnEnable()
    {
        LoadItems();
    }

    public void LoadItems()
    {
        StartCoroutine("LoadItemsCoroutine");
    }

    IEnumerator LoadItemsCoroutine()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
            yield return null;
        }

        for (int i = 0; i < inventory.items.Count; i++)
        {
            GameObject button = Instantiate(buttonPrefab, gameObject.transform);
            TextMeshProUGUI text = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Button buttonScript = button.GetComponent<Button>();
            ButtonIndex buttonItem = button.GetComponent<ButtonIndex>();
            buttonItem.SetIndex(i);
            text.text = inventory.items[i].GetItemName() + ": " + inventory.itemQuantities[i].ToString();
            buttonScript.onClick.AddListener(() => {
                detailsPage.SetItemTransfer(itemTransfer);
                detailsPage.SetItemName(inventory.items[buttonItem.GetIndex()].GetItemName());
                detailsPage.SetItemQuantity(inventory.itemQuantities[buttonItem.GetIndex()]);
                detailsPage.SetItemDescription(inventory.items[buttonItem.GetIndex()].GetDescription());
                detailsPage.SetItemBuyPrice(inventory.items[buttonItem.GetIndex()].GetBuyPrice());
                detailsPage.SetItemSellPrice(inventory.items[buttonItem.GetIndex()].GetSellPrice());
                detailsPage.DisactivateBuyButton();
                detailsPage.DisactivateSellButton();
                if(inventory.wallet > inventory.items[buttonItem.GetIndex()].GetBuyPrice())
                {
                    detailsPage.ActivateBuyButton(inventory.items[buttonItem.GetIndex()].GetBuyPrice());
                }
                if (inventory.itemQuantities[buttonItem.GetIndex()] > 0)
                {
                    detailsPage.ActivateSellButton(inventory.items[buttonItem.GetIndex()].GetSellPrice());
                }
                itemTransfer.SetItemID(buttonItem.GetIndex());
                detailsPage.Open();
                detailsPage.CheckForEmptyActions();
            });

            yield return null;
        }

        if (transform.childCount == 0)
        {
            emptyNotification.SetActive(true);
        }
        else
        {
            emptyNotification.SetActive(false);
        }

        walletAmount.text = "Wallet: $" + inventory.wallet.ToString();
    }
}
