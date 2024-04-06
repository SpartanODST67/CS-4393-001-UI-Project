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

    //Serialized to be visable in editor.
    [Header("Relationship Info")]
    [SerializeField] int characterIndex; //Difficult to read
    [SerializeField] int relationshipLevel = 0;
    [SerializeField] int relationshipPoints = 0;
    [SerializeField] string characterName; //Used to denote which dialogue node to start
    [SerializeField] bool isQuestComplete;
    [SerializeField] bool isOnTeam;
    [SerializeField] bool isLevelUpReady;
    [SerializeField] bool isMaxLevel;
    [SerializeField] float withdrawRate;
    [SerializeField] List<int> levelUpThresholds = new List<int>();

    [Header("Gift Preferrences")]
    [SerializeField] List<Item> likedGifts = new List<Item>();
    [SerializeField] List<Item> dislikedGifts = new List<Item>();

    [Header("Yarn Info")]
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] RelationshipBank relationshipBank;
    private InMemoryVariableStorage storage;
    public string interactionPrompt => prompt;

    void Start()
    {
        storage = FindObjectOfType<InMemoryVariableStorage>();
        StartCoroutine("PassiveWithdraw");
    }

    public bool Interact(Interactor interactor)
    {
        interactor.interactionPromptUI.Close();
        WithdrawRelationshipValues();
        isMaxLevel = IsMaxed();
        isLevelUpReady = DetermineLevelUpReady();
        UpdateYarnValues();
        TriggerDialogue();
        inputHandler.gameObject.SetActive(false);

        return true;
    }

    private void WithdrawRelationshipValues()
    {
        relationshipPoints = relationshipBank.GetRelationshipPoints(characterIndex);
        relationshipLevel = relationshipBank.GetRelationshipLevel(characterIndex);
        isOnTeam = relationshipBank.IsOnTeam(characterIndex);
    }

    IEnumerator PassiveWithdraw()
    {
        while(!isMaxLevel)
        {
            WithdrawRelationshipValues();
            isMaxLevel = IsMaxed();
            isLevelUpReady = DetermineLevelUpReady();
            yield return new WaitForSeconds(withdrawRate);
        }
    }

    private bool IsMaxed()
    {
        if(relationshipLevel == levelUpThresholds.Count)
        {
            return true;
        }
        return false;
    }

    private bool DetermineLevelUpReady()
    {
        if(isMaxLevel)
        {
            return false;
        }

        if(relationshipPoints >= levelUpThresholds[relationshipLevel])
        {
            return true;
        }
        return false;
    }

    private void UpdateYarnValues()
    {
        storage.SetValue("$characterIndex", characterIndex);
        storage.SetValue("$levelUp", isLevelUpReady);
        storage.SetValue("$onTeam", isOnTeam);
        storage.SetValue("$relationshipLevel", relationshipLevel);
        storage.SetValue("$questComplete", isQuestComplete);
    }

    private void TriggerDialogue()
    {
        dialogueRunner.StartDialogue(characterName);
    }

    public int DetermineGiftOpinion(int giftID)
    {
        if(DoesLike(giftID)) {
            return 1;
        }
        if(DoesDislike(giftID)) {
            return -1;
        }
        return 0;
        
    }

    private bool DoesLike(int giftID)
    {
        foreach(Item item in likedGifts)
        {
            if(giftID == item.GetItemID())
            {
                return true;
            }
        }
        return false;
    }

    private bool DoesDislike(int giftID)
    {
        foreach (Item item in dislikedGifts)
        {
            if (giftID == item.GetItemID())
            {
                return true;
            }
        }
        return false;
    }
}
