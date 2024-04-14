using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<GameObject> menus = new List<GameObject>();

    public void ActivateSpecificMenu(int index)
    {
        menus[index].gameObject.SetActive(true);
    }

    public void ActivateInventory(int mode)
    {
        menus[0].GetComponent<InventoryScreenManager>().Open(mode);
    }

    public void ActivateRelationships()
    {
        menus[1].gameObject.SetActive(true);
    }

    public void ActivateStoreInventory()
    {
        menus[2].gameObject.SetActive(true);
    }

    public void ActivateSaveMenu()
    {
        menus[3].gameObject.SetActive(true);
    }

    public void ActivateLoadMenu()
    {
        menus[4].gameObject.SetActive(true);
    }
}
