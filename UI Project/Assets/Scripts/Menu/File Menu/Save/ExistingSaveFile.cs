using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ExistingSaveFile : MonoBehaviour
{
    [Header("Save File")]
    public string fileName;
    [Header("To modify button behaviour")]
    [SerializeField] Button myButton;
    [SerializeField] TextMeshProUGUI buttonText;
    [Header("For status display")]
    private TextMeshProUGUI statusNotification;
    [SerializeField] string successStatusString = "Save Successful";
    [SerializeField] string failureStatusString = "Save Failed";

    public void SetFileName(string fileName)
    {
        this.fileName = fileName;
        SetDisplayName();
    }

    public void SetDisplayName()
    {
        buttonText.text = fileName.Split(".")[0];
    }

    public void SetDisplayName(string displayName)
    {
        buttonText.text = displayName;
    }

    public void SetStatusNotification(TextMeshProUGUI statusNotification)
    {
        this.statusNotification = statusNotification;
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
