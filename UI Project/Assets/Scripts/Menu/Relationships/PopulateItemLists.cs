using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PopulateItemLists : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;

    public void PopulateList(List<Item> list)
    {
        StartCoroutine(InstantiateItems(list));
    }

    IEnumerator InstantiateItems(List<Item> list)
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
            yield return null;
        }

        foreach (Item item in list)
        {
            TextMeshProUGUI displayText = Instantiate(textPrefab, transform).transform.GetChild(0).GetComponent<TextMeshProUGUI>();
            displayText.text = item.GetItemName();
            yield return null;
        }
    }
}