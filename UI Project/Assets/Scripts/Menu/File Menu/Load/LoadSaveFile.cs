using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSaveFile : MonoBehaviour
{
    [Header("File the game will load from")]
    public string fileName;
    [Header("To modify button behavior.")]
    [SerializeField] Button myButton;
    [SerializeField] TextMeshProUGUI buttonText;

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

    public Button GetButton()
    {
        return myButton;
    }
}
