using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadConfirmation : MonoBehaviour
{
    public string fileName;
    [SerializeField] Button confirmButton;

    public void SetLoadFile(string fileName)
    {
        this.fileName = fileName;
        confirmButton.onClick.RemoveAllListeners();
        confirmButton.onClick.AddListener(() =>
        {
            SaveSystem.instance.LoadGame();
            SceneManager.LoadScene("SampleScene");
        });
    }
}
