using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RelationshipBank")]
public class RelationshipBank : ScriptableObject
{
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
}
