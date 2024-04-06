using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Conversation : MonoBehaviour, Interactable
{
    [Header("Player Input Handler")]
    [SerializeField] InputHandler inputHandler;

    [Header("Interactable Info")]
    [SerializeField] string prompt = "Talk";
    [SerializeField] int characterIndex; //Difficult to read

    //Serialized to be visable in editor.
    [Header("Relationship Info")]
    [SerializeField] int relationshipLevel = 0;
    [SerializeField] int relationshipPoints = 0;
    [SerializeField] string characterName; //Used to denote which dialogue node to start
    [SerializeField] bool isQuestComplete;
    [SerializeField] bool isOnTeam;
    [SerializeField] bool isLevelUpReady;
    [SerializeField] List<int> levelUpThresholds = new List<int>();

    [Header("Yarn Info")]
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] RelationshipBank relationshipBank;
    private InMemoryVariableStorage storage;
    public string interactionPrompt => prompt;

    void Start()
    {
        storage = FindObjectOfType<InMemoryVariableStorage>();
    }

    public bool Interact(Interactor interactor)
    {
        interactor.interactionPromptUI.close();
        withdrawRelationshipValues();
        updateYarnValues();
        triggerDialogue();
        inputHandler.gameObject.SetActive(false);

        return true;
    }

    private void withdrawRelationshipValues()
    {
        relationshipPoints = relationshipBank.GetRelationshipPoints(characterIndex);
        relationshipLevel = relationshipBank.GetRelationshipLevel(characterIndex);
        isOnTeam = relationshipBank.IsOnTeam(characterIndex);
    }

    private void updateYarnValues()
    {
        //storage.SetValue("$levelUp", isLevelUpReady);
        storage.SetValue("$onTeam", isOnTeam);
        storage.SetValue("$relationshipLevel", relationshipLevel);
        storage.SetValue("$questComplete", isQuestComplete);
    }

    private void triggerDialogue()
    {
        dialogueRunner.StartDialogue(characterName);
    }
}
