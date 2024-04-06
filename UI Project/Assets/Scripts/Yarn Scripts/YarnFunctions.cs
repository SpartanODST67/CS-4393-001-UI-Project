using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour
{
    private static GameObject inputHandler;


    private void Start()
    {
        inputHandler = GameObject.FindGameObjectWithTag("Input Handler");
    }

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
        relationshipBank.SetRelationshipLevel(characterIndex, relationshipBank.GetRelationshipLevel(characterIndex) + 1);
    }

    [YarnCommand("updateOnTeamStatus")]
    public static void updateOnTeamStatus(int characterIndex)
    {
        RelationshipBank relationshipBank = FindAnyObjectByType<RelationshipBank>();
        if(relationshipBank.IsOnTeam(characterIndex))
        {
            relationshipBank.SetOnTeam(characterIndex, false);
        }
        else
        {
            relationshipBank.SetOnTeam(characterIndex, true);
        }
    }

    [YarnCommand("giveNewQuest")]
    public static void giveNewQuest(int characterIndex, int questID)
    {
        //Temp
        RelationshipBank relationshipBank = FindAnyObjectByType<RelationshipBank>();
        //relationshipBank.setQuestCompletion(characterIndex, false);
        Debug.Log("You still need to implement this dumbass.");
    }

    [YarnCommand("endConversation")]
    public static void endConversation()
    {
        inputHandler.gameObject.SetActive(true);
    }
}
