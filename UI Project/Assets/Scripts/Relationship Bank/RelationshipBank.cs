using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RelationshipBank")]
public class RelationshipBank : ScriptableObject
{
    public List<Conversation> characters = new List<Conversation>();
    public List<int> relationshipLevels = new List<int>();
    public List<int> relationshipPoints = new List<int>();
    public List<bool> onTeam = new List<bool>();

    public int GetRelationshipLevel(int i)
    {
        return relationshipLevels[i];
    }

    public void SetRelationshipLevel(int i, int level)
    {
        relationshipLevels[i] = level;
    }

    public void LevelUp(int i)
    {
        relationshipLevels[i]++;
    }

    public void LevelUp(int i, int amount)
    {
        relationshipLevels[i] += amount;
    }

    public int GetRelationshipPoints(int i)
    {
        return relationshipPoints[i];
    }

    public void SetRelationshipPoints(int i, int points)
    {
        relationshipPoints[i] = points;
    }

    public void AddRelationshipPoints(int i, int points)
    {
        relationshipPoints[i] += points;
    }

    public bool IsOnTeam(int i)
    {
        return onTeam[i];
    }

    public void SetOnTeam(int i, bool status)
    {
        onTeam[i] = status;
    }

    public void LoadLevels(string line)
    {
        string[] entries = line.Split(",");
        for (int i = 0; i < entries.Length; i++)
        {
            relationshipLevels[i] = int.Parse(entries[i]);
        }
    }

    public void LoadPoints(string line)
    {
        string[] entries = line.Split(",");
        for (int i = 0; i < entries.Length; i++)
        {
            relationshipPoints[i] = int.Parse(entries[i]);
        }
    }

    public void LoadOnTeam(string line)
    {
        string[] entries = line.Split(",");
        for (int i = 0; i < entries.Length; i++)
        {
            onTeam[i] = bool.Parse(entries[i]);
        }
    }

    public string ToCSV()
    {
        StringBuilder fullString = new StringBuilder();
        StringBuilder levels = new StringBuilder();
        StringBuilder points = new StringBuilder();
        StringBuilder onTeamSB = new StringBuilder();

        foreach(int level in relationshipLevels)
        {
            levels.Append(level.ToString());
            levels.Append(",");
        }
        levels.Length--;

        foreach(int point in relationshipPoints)
        {
            points.Append(point.ToString());
            points.Append(",");
        }
        points.Length--;

        foreach(bool status in onTeam)
        {
            onTeamSB.Append(status.ToString());
            onTeamSB.Append(",");
        }
        onTeamSB.Length--;

        fullString.AppendLine(levels.ToString());
        fullString.AppendLine(points.ToString());
        fullString.AppendLine(onTeamSB.ToString());

        return fullString.ToString();
    }
}
