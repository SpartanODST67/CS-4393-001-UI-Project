using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour
{
    [YarnCommand("loadRelationshipScene")]
    public static void loadRelationshipScene(string sceneName)
    {
        Debug.Log(string.Format("{0} is loading.", sceneName));
        SceneManager.LoadScene(sceneName);
    }

    [YarnCommand("relationshipLevelUp")]
    public static void relationshipLevelUp(int characterIndex)
    {
        RelationshipBank relationshipBank = FindAnyObjectByType<RelationshipBank>();
        relationshipBank.setRelationshipLevel(characterIndex, relationshipBank.getRelationshipLevel(characterIndex) + 1);
    }

    [YarnCommand("updateOnTeamStatus")]
    public static void updateOnTeamStatus(int characterIndex)
    {
        RelationshipBank relationshipBank = FindAnyObjectByType<RelationshipBank>();
        if(relationshipBank.isOnTeam(characterIndex))
        {
            relationshipBank.setOnTeam(characterIndex, false);
        }
        else
        {
            relationshipBank.setOnTeam(characterIndex, true);
        }
    }

    [YarnCommand("giveNewQuest")]
    public static void giveNewQuest(int characterIndex, int questID)
    {
        //Temp
        RelationshipBank relationshipBank = FindAnyObjectByType<RelationshipBank>();
        relationshipBank.setQuestCompletion(characterIndex, false);
        Debug.Log("You still need to implement this dumbass.");
    }

    [YarnCommand("endConversation")]
    public static void endConversation()
    {
        StateManager stateManager = FindAnyObjectByType<StateManager>();
        stateManager.setWandering();
    }
}
