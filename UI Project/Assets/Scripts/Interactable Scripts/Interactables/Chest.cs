using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour, Interactable
{
    [SerializeField] string prompt = "Open";

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Opening Chest");
        return true;
    }
}
