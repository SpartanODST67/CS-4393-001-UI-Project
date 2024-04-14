using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class StoreBack : MonoBehaviour
{
    [SerializeField] DialogueRunner dialogueRunner;
    [SerializeField] string targetDialogue;
    [SerializeField] GameObject closingScreen;
    [SerializeField] Button myself;

    private void OnEnable()
    {
        myself.onClick.RemoveAllListeners();
        myself.onClick.AddListener(() =>
        {
            closingScreen.SetActive(false);
            dialogueRunner.StartDialogue(targetDialogue);
        });
    }
}
