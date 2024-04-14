using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScreenManager : MonoBehaviour
{
    [Header("Mode 0 - Default Mode. Mode 1 - Gift Menu. Mode 2 - Opened Via Keypress.")]
    [SerializeField] int mode = 0;
    [Header("Closes the menu but does not return control.")]
    [SerializeField] GameObject backButton;
    [Header("Closes the menu and returns control.")]
    [SerializeField] GameObject fullBackButton;
    [Header("For use when the player changes their mind of gifting an object.")]
    [SerializeField] GameObject nevermindButton;
    [Header("Buttons in the details page")]
    [SerializeField] GameObject giftButton;
    [SerializeField] GameObject discardButton;

    private void OnEnable()
    {
        switch (mode)
        {
            case 1:
                backButton.SetActive(false);
                fullBackButton.SetActive(false);
                nevermindButton.SetActive(true);
                giftButton.SetActive(true);
                discardButton.SetActive(false);
                break;
            case 2:
                backButton.SetActive(false);
                fullBackButton.SetActive(true);
                nevermindButton.SetActive(false);
                giftButton.SetActive(false);
                discardButton.SetActive(true);
                discardButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Open(2);
                });
                break;
            default:
                backButton.SetActive(true);
                fullBackButton.SetActive(false);
                nevermindButton.SetActive(false);
                giftButton.SetActive(false);
                discardButton.SetActive(true);
                discardButton.GetComponent<Button>().onClick.AddListener(() =>
                {
                    Open(0);
                });
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
