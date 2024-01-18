using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour, Interactable
{
    [SerializeField] string prompt = "Walk";
    [SerializeField] string destinationScene;
    public string interactionPrompt => prompt;

    public bool Interact(Interactor interactor)
    {
        Debug.Log("Step, step, step.");
        DestroyAllPositionSavers();
        SceneManager.LoadScene(destinationScene); //Debug. Update to load next scene
        return true;
    }

    public void DestroyAllPositionSavers()
    {
        GameObject[] positionSavers = GameObject.FindGameObjectsWithTag("Position Saver");
        foreach(GameObject positionSaver in positionSavers)
        {
            Destroy(positionSaver);
        }
    }
}
