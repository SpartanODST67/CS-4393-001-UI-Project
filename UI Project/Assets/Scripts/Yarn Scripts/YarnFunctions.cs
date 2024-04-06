using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour
{
    private static GameObject inputHandler;
    private static RelationshipBank relationshipBank;

    private void Start()
    {
        relationshipBank = GameObject.Find("Relationship Bank Storage").GetComponent<RelationshipBankStorage>().relationshipBank;
        inputHandler = GameObject.FindGameObjectWithTag("Input Handler");
    }

    [YarnCommand("LoadRelationshipScene")]
    public static void LoadRelationshipScene(string sceneName)
    {
        Debug.Log(string.Format("{0} is loading.", sceneName));
        SceneManager.LoadScene(sceneName);
    }

    [YarnCommand("RelationshipLevelUp")]
    public static void RelationshipLevelUp(int characterIndex)
    {
        relationshipBank.SetRelationshipLevel(characterIndex, relationshipBank.GetRelationshipLevel(characterIndex) + 1);
    }

    //Don't worry about this one too :)
    [YarnCommand("UpdateOnTeamStatus")]
    public static void UpdateOnTeamStatus(int characterIndex)
    {
        if(relationshipBank.IsOnTeam(characterIndex))
        {
            relationshipBank.SetOnTeam(characterIndex, false);
        }
        else
        {
            relationshipBank.SetOnTeam(characterIndex, true);
        }
    }

    //We're not going to use this function :)
    [YarnCommand("GiveNewQuest")]
    public static void GiveNewQuest(int characterIndex, int questID)
    {
        //Temp
        //relationshipBank.setQuestCompletion(characterIndex, false);
        Debug.Log("You still need to implement this dumbass.");
    }

    [YarnCommand("EndConversation")]
    public static void EndConversation()
    {
        inputHandler.gameObject.SetActive(true);
    }
}
