using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] List<GameObject> menus = new List<GameObject>();

    public void ActivateInventory(int mode)
    {
        menus[0].GetComponent<InventoryScreenManager>().Open(mode);
    }

    public void ActivateRelationships()
    {
        menus[1].gameObject.SetActive(true);
    }
}
