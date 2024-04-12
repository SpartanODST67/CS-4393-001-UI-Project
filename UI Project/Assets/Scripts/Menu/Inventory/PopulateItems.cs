using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PopulateItems : MonoBehaviour
{
    [Header("Background Systems")]
    [SerializeField] Inventory inventory;
    [SerializeField] ItemTransfer itemTransfer;
    [Header("Displayed Systems")]
    [SerializeField] GameObject buttonPrefab;
    [SerializeField] DetailsManager detailsPage;
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
            if (inventory.itemQuantities[i] <= 0)
            {
                continue;
            }

            GameObject button = Instantiate(buttonPrefab, gameObject.transform);
            TextMeshProUGUI text = button.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            Button buttonScript = button.GetComponent<Button>();
            ButtonIndex buttonItem = button.GetComponent<ButtonIndex>();
            buttonItem.SetIndex(i);
            text.text = inventory.items[i].GetItemName() + ": " + inventory.itemQuantities[i].ToString();
            buttonScript.onClick.AddListener(() => {
                detailsPage.SetItemName(inventory.items[buttonItem.GetIndex()].GetItemName());
                detailsPage.SetItemQuantity(inventory.itemQuantities[buttonItem.GetIndex()]);
                detailsPage.SetItemDescription(inventory.items[buttonItem.GetIndex()].GetDescription());
                detailsPage.SetItemBuyPrice(inventory.items[buttonItem.GetIndex()].GetBuyPrice());
                detailsPage.SetItemSellPrice(inventory.items[buttonItem.GetIndex()].GetSellPrice());
                itemTransfer.SetItemID(buttonItem.GetIndex());
                detailsPage.Open(); 
            });

            yield return null;
        }

        if(transform.childCount == 0)
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
