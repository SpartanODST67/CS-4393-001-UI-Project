using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class Conversation : MonoBehaviour, Interactable
{
    [Header("Interactable Info")]
    [SerializeField] string prompt = "Talk";
    [SerializeField] int characterIndex; //Difficult to read

    //Serialized to be visable in editor.
    [Header("Relationship Info")]
    //[SerializeField] 
    [SerializeField] float relationshipLevel = 0;
    [SerializeField] string characterName; //Used to denote which dialogue node to start
    [SerializeField] bool isQuestComplete;
    [SerializeField] bool isOnTeam;
    [SerializeField] bool isLevelUpReady;

    [Header("Yarn Info")]
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] string startNode;
    private RelationshipBank relationshipBank;
    private StateManager stateManager;
    private InMemoryVariableStorage storage;
    public string interactionPrompt => prompt;

    void Start()
    {
        relationshipBank = FindObjectOfType<RelationshipBank>();
        storage = FindObjectOfType<InMemoryVariableStorage>();
        stateManager = FindObjectOfType<StateManager>();
    }

    public bool Interact(Interactor interactor)
    {
        interactor.interactionPromptUI.gameObject.SetActive(false);
        withdrawRelationshipValues();
        updateYarnValues();
        triggerDialogue();
        stateManager.setTalking();

        return true;
    }

    private void withdrawRelationshipValues()
    {
        relationshipLevel = relationshipBank.getRelationshipLevel(characterIndex);
        characterName = relationshipBank.getCharacterName(characterIndex);
        isQuestComplete = relationshipBank.isQuestComplete(characterIndex);
        isOnTeam = relationshipBank.isOnTeam(characterIndex);
        isLevelUpReady = relationshipBank.isLevelUpReady(characterIndex);
    }

    private void updateYarnValues()
    {
        storage.SetValue("$levelUp", isLevelUpReady);
        storage.SetValue("$onTeam", isOnTeam);
        storage.SetValue("$relationshipLevel", relationshipLevel);
        storage.SetValue("$questComplete", isQuestComplete);
    }

    private void triggerDialogue()
    {
        dialogueRunner.StartDialogue(characterName);
    }
}
