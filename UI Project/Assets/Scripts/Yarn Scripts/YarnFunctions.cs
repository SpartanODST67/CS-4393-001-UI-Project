using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Yarn.Unity;

public class YarnFunctions : MonoBehaviour
{
    private static GameObject inputHandler;
    private static RelationshipBank relationshipBank;
    private static MenuManager menuManager;

    private void Start()
    {
        relationshipBank = GameObject.Find("Relationship Bank Storage").GetComponent<RelationshipBankStorage>().relationshipBank;
        inputHandler = GameObject.FindGameObjectWithTag("Input Handler");
        menuManager = GameObject.FindGameObjectWithTag("Game Menus").GetComponent<MenuManager>();
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
        relationshipBank.LevelUp(characterIndex);
    }

    [YarnCommand("RewardRelationshipPoints")]
    public static void RewardRelationshipPoints(int characterIndex, int points)
    {
        relationshipBank.relationshipPoints[characterIndex] += points;
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

    [YarnCommand("OpenInventory")]
    public static void OpenInventory(int mode)
    {
        menuManager.ActivateInventory(mode);
    }
}
