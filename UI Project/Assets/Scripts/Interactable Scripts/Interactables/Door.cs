using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, Interactable
{
    [SerializeField] string prompt = "Enter";
    [SerializeField] int doorNum;
    [SerializeField] GameObject positionSaverPrefab;
    [SerializeField] string destinationScene;
    private PositionSaver positionSaverScript;
    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        positionSaverScript = Instantiate(positionSaverPrefab).GetComponent<PositionSaver>();
        positionSaverScript.SetDoorNum(doorNum);
        positionSaverScript.SetOriginScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(destinationScene);
        return true;
    }

    public int GetDoorNum() 
    { 
        return doorNum; 
    }
}
