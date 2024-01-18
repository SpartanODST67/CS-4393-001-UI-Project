using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RelationshipBank : MonoBehaviour
{
    private struct CharacterRelationshipInformation
    {
        public string name;
        public int relationshipLevel;
        public bool isQuestComplete;
        public bool isOnTeam;
        public bool isLevelUpReady;

        public CharacterRelationshipInformation(string name, int relationshipLevel, bool isQuestComplete, bool isOnTeam, bool isLevelUpReady)
        {
            this.name = name;
            this.relationshipLevel = relationshipLevel;
            this.isQuestComplete = isQuestComplete;
            this.isOnTeam = isOnTeam;
            this.isLevelUpReady = isLevelUpReady;
        }
    }

    private CharacterRelationshipInformation[] relationshipInformation;

    private void Start()
    {
        //check for load data
        //exists: loadRelationshipData()
        //else: initializeRelationshipData()
        DebugInitializeRelationshipData();
    }

    //Find save file and load data from it.
    private void loadRelationshipData()
    {
        throw new System.NotImplementedException();
    }


    //Add to save file;
    private void saveRelationshipData()
    {
        throw new System.NotImplementedException();
    }

    private void initializeRelationshipData()
    {
        string[] characterNames = { "Mark", "Char 2", "Char 3", "Char 4", "Char 5", "Char 6", "Char 7", "Char 8", "Char 9", "Char 10" };
        relationshipInformation = new CharacterRelationshipInformation[characterNames.Length];
        for(int i = 0; i < characterNames.Length; i++)
        {
            relationshipInformation[i] = new CharacterRelationshipInformation(characterNames[i], -1, false, false, false);
        }
    }

    //This is trash and needs to be removed. Only here to make sure other systems can work.
    private void DebugInitializeRelationshipData()
    {
        CharacterRelationshipInformation c1 = new CharacterRelationshipInformation("Mark", -1, false, false, true);
        CharacterRelationshipInformation c2 = new CharacterRelationshipInformation("Char 2", -1, false, false, false);
        CharacterRelationshipInformation c3 = new CharacterRelationshipInformation("Char 3", -1, false, false, false);
        CharacterRelationshipInformation c4 = new CharacterRelationshipInformation("Char 4", -1, false, false, false);
        CharacterRelationshipInformation c5 = new CharacterRelationshipInformation("Char 5", -1, false, false, false);
        CharacterRelationshipInformation c6 = new CharacterRelationshipInformation("Char 6", -1, false, false, false);
        CharacterRelationshipInformation c7 = new CharacterRelationshipInformation("Char 7", -1, false, false, false);
        CharacterRelationshipInformation c8 = new CharacterRelationshipInformation("Char 8", -1, false, false, false);
        CharacterRelationshipInformation c9 = new CharacterRelationshipInformation("Char 9", -1, false, false, false);
        CharacterRelationshipInformation c10 = new CharacterRelationshipInformation("Char 10", -1, false, false, false);
        relationshipInformation = new CharacterRelationshipInformation[10];
        relationshipInformation[0] = c1;
        relationshipInformation[1] = c2;
        relationshipInformation[2] = c3;
        relationshipInformation[3] = c4;
        relationshipInformation[4] = c5;
        relationshipInformation[5] = c6;
        relationshipInformation[6] = c7;
        relationshipInformation[7] = c8;
        relationshipInformation[8] = c9;
        relationshipInformation[9] = c10;
    }

    public string getCharacterName(int i)
    {
        return relationshipInformation[i].name;
    }

    public int getRelationshipLevel(int i)
    {
        return relationshipInformation[i].relationshipLevel;
    }

    public bool isQuestComplete(int i)
    {
        return relationshipInformation[i].isQuestComplete;
    }

    public bool isOnTeam(int i)
    {
        return relationshipInformation[i].isOnTeam;
    }

    public bool isLevelUpReady(int i)
    {
        return relationshipInformation[i].isLevelUpReady;
    }

    public void setCharacterName(int i, string name)
    {
        relationshipInformation[i].name = name;
    }

    public void setRelationshipLevel(int i, int relationshipLevel)
    {
        relationshipInformation[i].relationshipLevel = relationshipLevel;
    }

    public void setQuestCompletion(int i, bool questCompletion)
    {
        relationshipInformation[i].isQuestComplete = questCompletion;
    }

    public void setOnTeam(int i, bool isOnTeam)
    {
        relationshipInformation[i].isOnTeam = isOnTeam;
    }

    public void setLevelUpReady(int i, bool isLevelUpReady)
    {
        relationshipInformation[i].isLevelUpReady = isLevelUpReady;
    }
}
