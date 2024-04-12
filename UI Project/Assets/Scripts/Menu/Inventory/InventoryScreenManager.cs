using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScreenManager : MonoBehaviour
{
    [SerializeField] int mode = 0;
    [SerializeField] GameObject backButton;
    [SerializeField] GameObject nevermindButton;

    private void OnEnable()
    {
        switch (mode)
        {
            case 1:
                backButton.SetActive(false);
                nevermindButton.SetActive(true);
                break;
            default:
                backButton.SetActive(true);
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
