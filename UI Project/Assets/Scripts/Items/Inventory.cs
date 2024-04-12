using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Inventory")]
public class Inventory : ScriptableObject
{
    public List<Item> items = new List<Item>();
    public List<int> itemQuantities = new List<int>();
    public int wallet;
    
    public void AddItemQuantity(int index)
    {
        itemQuantities[index]++;
    }

    public void AddItemQuantity(int index, int count)
    {
        itemQuantities[index] += count;
    }

    public void RemoveItemQuantity(int index)
    {
        if(index < 0)
        {
            return;
        }
        itemQuantities[index]--;
    }

    public void RemoveItemQuantity(int index, int count)
    {
        itemQuantities[index] -= count;
    }

    public int GetItemQuantity(int index)
    {
        return itemQuantities[index];
    }

    //Takes a csv line and converts it to the inventory quantities.
    public void FromCSV(string line)
    {
        string[] entries = line.Split(",");
        for(int i = 0; i < entries.Length - 1; i++)
        {
            itemQuantities[i] = int.Parse(entries[i]);
        }
        wallet = int.Parse(entries[entries.Length - 1]);
    }

    //Converts the inventory to a csv series of numbers.
    public string ToCSV()
    {
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < itemQuantities.Count; i++)
        {
            sb.Append(itemQuantities[i].ToString());
            sb.Append(",");
        }
        sb.Append(wallet.ToString());
        return sb.ToString();
    }
}
