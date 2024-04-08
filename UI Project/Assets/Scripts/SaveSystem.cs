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
}
