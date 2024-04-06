using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InteractionPromptUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI displayText;
    [SerializeField] GameObject uiPanel;
    private bool isDeactive;

    public void Open(string promptText)
    {
        displayText.text = promptText;
        uiPanel.SetActive(true);
        isDeactive = false;
    }

    public void Close()
    {
        uiPanel.SetActive(false);
        isDeactive = true;
    }

    public bool IsActive()
    {
        return !isDeactive;
    }
}
