using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("Item Data")]
    [SerializeField] string itemName;
    [SerializeField] string itemDescription;
    [SerializeField] int buyPrice;
    [SerializeField] int sellPrice;

    [Header("For Display")]
    [SerializeField] GameObject myselfPrefab;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); //Might be better to disable and enable the object instead of destorying and instantiating.
        }
    }
}
