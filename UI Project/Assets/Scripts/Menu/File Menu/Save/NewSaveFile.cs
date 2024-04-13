using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewSaveFile : MonoBehaviour
{
    [Header("Save File")]
    public string fileName;
    [Header("To store initialized data")]
    [SerializeField] Inventory inventory;
    [SerializeField] RelationshipBank relationshipBank;
    [Header("To modify listeners")]
    [SerializeField] Button myButton;
    [Header("For status display")]
    [SerializeField] TextMeshProUGUI statusNotification;
    [SerializeField] string successStatusString = "Save Successful";
    [SerializeField] string failureStatusString = "Save Failed";

    public void SetFileName(string fileName)
    {
        this.fileName = fileName;
    }

    public void SetStatusNotification(TextMeshProUGUI statusNotification)
    {
        this.statusNotification = statusNotification;
    }

    public string GetFileName()
    {
        return fileName;
    }

    public Inventory GetInventory()
    {
        return inventory;
    }

    public RelationshipBank GetRelationshipBank()
    {
        return relationshipBank;
    }

    public Button GetButton()
    {
        return myButton;
    }

    public void ShowStatusSuccess()
    {
        statusNotification.color = Color.white;
        statusNotification.text = successStatusString;
        statusNotification.gameObject.transform.parent.gameObject.SetActive(true);
    }

    public void ShowStatusFailure()
    {
        statusNotification.color = Color.red;
        statusNotification.text = failureStatusString;
        statusNotification.gameObject.transform.parent.gameObject.SetActive(true);
    }
}