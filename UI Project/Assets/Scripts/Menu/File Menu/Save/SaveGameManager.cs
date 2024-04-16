using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.LookDev;
using UnityEngine.SceneManagement;

public class SaveGameManager : MonoBehaviour
{
    [Header("Prefab button for existing save files")]
    [SerializeField] GameObject existingSaveButton;
    [Header("Script button for new save files")]
    [SerializeField] NewSaveFile newSaveButton;
    [Header("For status report")]
    [SerializeField] TextMeshProUGUI saveStatusText;
    [Header("Found Save Files")]
    [SerializeField] List<string> fileNames = new List<string>();
    [Header("Determines if scene is loaded when pressing new save")]
    [SerializeField] bool newGame = true;

    private void OnEnable()
    {
        string[] saveFiles = SaveSystem.instance.GetSavedGames();
        StartCoroutine(PopulateSaveFiles(saveFiles));
    }

    IEnumerator PopulateSaveFiles(string[] saveFiles)
    {
        fileNames.Clear();
        for (int i = transform.childCount - 1; i > 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
            yield return null;
        }

        foreach (string file in saveFiles)
        {
            ExistingSaveFile newButton = Instantiate(existingSaveButton, transform).GetComponent<ExistingSaveFile>();
            string[] filePathSplit = file.Split("/");
            string fileName = filePathSplit[filePathSplit.Length - 1];
            fileNames.Add(fileName);
            newButton.SetFileName(fileName);
            newButton.SetStatusNotification(saveStatusText);
            newButton.GetButton().onClick.AddListener(() =>
            {
                if (!newGame)
                {
                    SaveSystem.instance.SetFileName(newButton.fileName);
                    try
                    {
                        SaveSystem.instance.SaveGame();
                    }
                    catch (Exception e)
                    {
                        newButton.ShowStatusFailure();
                        return;
                    }
                    newButton.ShowStatusSuccess();
                }
                else
                {
                    newSaveButton.GetInventory().InitializeInventory();
                    newSaveButton.GetRelationshipBank().InitializeRelationshipBank();
                    try
                    {
                        SaveSystem.instance.SaveGame();
                    }
                    catch (Exception e)
                    {
                        Debug.LogException(e);
                        newSaveButton.ShowStatusFailure();
                        return;
                    }
                    SceneManager.LoadScene("SampleScene");
                }
            });
            yield return null;
        }

        string newFileName = "file" + fileNames.Count.ToString() + ".csv";
        newSaveButton.SetFileName(newFileName);
        newSaveButton.GetButton().onClick.AddListener(() =>
        {
            if (newGame)
            {
                newSaveButton.GetInventory().InitializeInventory();
                newSaveButton.GetRelationshipBank().InitializeRelationshipBank();
            }
            SaveSystem.instance.SetFileName(newSaveButton.GetFileName());
            try
            {
                SaveSystem.instance.SaveGame();
                if(!newGame)
                {
                    newSaveButton.ShowStatusSuccess();
                }
            }
            catch (Exception e)
            {
                Debug.LogException(e);
                newSaveButton.ShowStatusFailure();
                return;
            }
            if (newGame)
            {
                SceneManager.LoadScene("SampleScene");
            }
            else
            {
                gameObject.transform.parent.gameObject.SetActive(false);
                gameObject.transform.parent.gameObject.SetActive(true);
            }
        });
        newSaveButton.gameObject.SetActive(true);
    }
}
