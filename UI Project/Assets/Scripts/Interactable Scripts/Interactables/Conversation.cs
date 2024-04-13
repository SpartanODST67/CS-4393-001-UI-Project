using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn.Unity;

public class Conversation : MonoBehaviour, Interactable
{
    [Header("Player Input Handler")]
    [SerializeField] InputHandler inputHandler;
    [SerializeField] ItemTransfer itemTransfer;

    [Header("Interactable Info")]
    [SerializeField] string prompt = "Talk";
    [SerializeField] SpeechBubble speechBubble;

    //Serialized to be visable in editor.
    [Header("Relationship Info")]
    [SerializeField] int characterIndex; //Difficult to read
    [SerializeField] int relationshipLevel = 0;
    [SerializeField] int relationshipPoints = 0;
    [SerializeField] string characterName; //Used to denote which dialogue node to start
    private string startNode;
    [SerializeField] string characterDescription;
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
    [SerializeField] InMemoryVariableStorage storage;
    [SerializeField] RelationshipBank relationshipBank;
    public string interactionPrompt => prompt;

    void Start()
    {
        startNode = characterName.Replace(" ", "");
        startNode = startNode.Replace(".", "");
        StartCoroutine("PassiveWithdraw");
    }

    public bool Interact(Interactor interactor)
    {
        interactor.interactionPromptUI.Close();
        itemTransfer.SetTargetCharacter(this);
        WithdrawRelationshipValues();
        isMaxLevel = IsMaxed();
        isLevelUpReady = DetermineLevelUpReady();
        UpdateYarnValues();
        UpdateSpeechBubble();
        TriggerDialogue();
        inputHandler.gameObject.SetActive(false);

        return true;
    }

    private void WithdrawRelationshipValues()
    {
        try
        {
            relationshipPoints = relationshipBank.GetRelationshipPoints(characterIndex);
            relationshipLevel = relationshipBank.GetRelationshipLevel(characterIndex);
            isOnTeam = relationshipBank.IsOnTeam(characterIndex);
        } catch (Exception e)
        {
            Debug.Log("whoops");
        }
    }

    IEnumerator PassiveWithdraw()
    {
        while(!isMaxLevel)
        {
            WithdrawRelationshipValues();
            isMaxLevel = IsMaxed();
            isLevelUpReady = DetermineLevelUpReady();
            UpdateSpeechBubble();
            yield return new WaitForSeconds(withdrawRate);
        }
    }

    private bool IsMaxed()
    {
        if(relationshipLevel >= levelUpThresholds.Count)
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

    private void UpdateSpeechBubble()
    {
        if(isMaxLevel)
        {
            speechBubble.SetDone();
        }
        else if(isLevelUpReady)
        {
            speechBubble.SetAlert();
        }
        else
        {
            speechBubble.SetNeutral();
        }
    }

    private void TriggerDialogue()
    {
        dialogueRunner.StartDialogue(startNode);
    }

    public void ReceiveGift(int giftID)
    {
        StringBuilder targetNode = new StringBuilder(startNode);
        if (giftID == -1)
        {
            targetNode.Append("Nevermind");
        }
        else
        {
            switch (DetermineGiftOpinion(giftID))
            {
                case -1:
                    targetNode.Append("Disgratitude");
                    break;
                case 0:
                    targetNode.Append("Satisfied");
                    break;
                case 1:
                    targetNode.Append("Gratitude");
                    break;

            }
        }
        dialogueRunner.StartDialogue(targetNode.ToString());
    }

    private int DetermineGiftOpinion(int giftID)
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

    public string GetCharacterName()
    {
        return characterName;
    }

    public string GetCharacterDescription()
    {
        return characterDescription;
    }

    public int GetMaxLevels()
    {
        return levelUpThresholds.Count;
    }

    public int GetCurrentThreshold()
    {
        return levelUpThresholds[relationshipLevel];
    }

    public int GetPreviousThreshold()
    {
        if (relationshipLevel <= 0)
        {
            return 0;
        }
        return levelUpThresholds[relationshipLevel - 1];
    }

    public int GetSpecificThreshold(int level)
    {
        if(level < 0)
        {
            return 0;
        }
        return levelUpThresholds[level];
    }

    public List<Item> GetLikedItems()
    {
        return likedGifts;
    }

    public List<Item> GetDislikedItems()
    {
        return dislikedGifts;
    }
}
