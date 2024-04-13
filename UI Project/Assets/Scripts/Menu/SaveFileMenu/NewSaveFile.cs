using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSaveFile : MonoBehaviour
{
    public string fileName;
    [SerializeField] Inventory inventory;
    [SerializeField] RelationshipBank relationshipBank;
    [SerializeField] Button myButton;

    public void OnEnable()
    {
        myButton.onClick.AddListener(() =>
            {
                StopAllCoroutines();
                inventory.InitializeInventory();
                relationshipBank.InitializeRelationshipBank();
                SaveSystem.instance.SetFileName(fileName);
                SaveSystem.instance.SaveGame();
                SceneManager.LoadScene("SampleScene");
            });
    }
}
