using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreenManager : MonoBehaviour
{
    [Header("Denotes which back button is activated.")]
    [SerializeField] int mode = 0;
    [Header("Closes the menu but does not return control.")]
    [SerializeField] GameObject backButton;
    [Header("Closes the menu and returns control.")]
    [SerializeField] GameObject fullBackButton;
    [Header("For use when the player changes their mind of gifting an object.")]
    [SerializeField] GameObject nevermindButton;

    private void OnEnable()
    {
        switch (mode)
        {
            case 1:
                backButton.SetActive(false);
                fullBackButton.SetActive(false);
                nevermindButton.SetActive(true);
                break;
            case 2:
                backButton.SetActive(false);
                fullBackButton.SetActive(true);
                nevermindButton.SetActive(false);
                break;
            default:
                backButton.SetActive(true);
                fullBackButton.SetActive(false);
                nevermindButton.SetActive(false);
                break;
        }
    }

    public void Open(int mode)
    {
        this.mode = mode;
        gameObject.SetActive(true);
    }

    public void Close()
    {
        mode = 0;
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        mode = 0;
    }
}
