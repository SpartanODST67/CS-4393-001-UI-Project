using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour, Interactable
{
    [SerializeField] string prompt = "Shop";

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Behold, my wares.");
        return true;
    }
}
