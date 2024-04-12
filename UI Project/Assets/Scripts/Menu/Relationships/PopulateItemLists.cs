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
        foreach (GameObject child in gameObject.transform)
        {
            Destroy(child);
            yield return null;
        }

        foreach (Item item in list)
        {
            TextMeshProUGUI displayText = Instantiate(textPrefab, gameObject.transform).GetComponent<TextMeshProUGUI>();
            displayText.text = item.GetItemName();
            yield return null;
        }
    }
}