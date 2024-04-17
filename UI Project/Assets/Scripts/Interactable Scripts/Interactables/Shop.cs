using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Shop : MonoBehaviour, Interactable
{
    [SerializeField] string prompt = "Shop";
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] string startNode = "Shopkeeper";
    [SerializeField] GameObject inputHandler;

    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        interactor.interactionPromptUI.Close();
        TriggerDialogue();
        inputHandler.gameObject.SetActive(false);

        return true;
    }

    public void TriggerDialogue()
    {
        dialogueRunner.StartDialogue(startNode);
    }
}
