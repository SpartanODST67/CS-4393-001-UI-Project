using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.IO;

public class SaveSystem : MonoBehaviour
{
    [Header("Saved Items")]
    [SerializeField] Inventory inventory;
    [SerializeField] RelationshipBank relationshipBank;

    [Header("Save Location")]
    [SerializeField] string fileName;
    [SerializeField] string folderPath = "./Resources/Save Files/";

    public void SaveGame()
    {
        StringBuilder path = new StringBuilder(folderPath);
        path.Append(fileName);

        string filePath = path.ToString();
        string inventorySave = inventory.ToCSV();
        string relationshipBankSave = relationshipBank.ToCSV();

        StringBuilder saveData = new StringBuilder(inventorySave);
        saveData.Append("\n");
        saveData.Append(relationshipBankSave);

        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        if(!File.Exists(filePath))
        {
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(saveData.ToString());
            }
        }
        else
        {
            StreamWriter newFile = File.CreateText(filePath);
            newFile.Write(saveData.ToString());
        }
    }

    public string[] GetSavedGames()
    {
        if(!Directory.Exists(folderPath))
        {
            return null;
        }
        return Directory.GetFiles(folderPath);
    }

    public int CountSavedGames()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            return 0;
        }
        return Directory.GetFiles(folderPath).Length;
    }

    public void LoadGame()
    {
        if(!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            return;
        }

        StringBuilder path = new StringBuilder(folderPath);
        path.Append(fileName);

        string filePath = path.ToString();

        if(!File.Exists(filePath))
        {
            return;
        }

        StreamReader sr = File.OpenText(filePath);

        inventory.FromCSV(sr.ReadLine());
        relationshipBank.LoadLevels(sr.ReadLine());
        relationshipBank.LoadPoints(sr.ReadLine());
        relationshipBank.LoadOnTeam(sr.ReadLine());
    }
}
