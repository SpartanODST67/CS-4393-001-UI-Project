using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/RelationshipBank")]
public class RelationshipBank : ScriptableObject
{
    public List<int> relationshipLevels = new List<int>();
    public List<int> relationshipPoints = new List<int>();
    public List<bool> onTeam = new List<bool>();

    public int getRelationshipLevel(int i)
    {
        return relationshipLevels[i];
    }

    public void setRelationshipLevel(int i, int level)
    {
        relationshipLevels[i] = level;
    }

    public bool isOnTeam(int i)
    {
        return onTeam[i];
    }

    public void setOnTeam(int i, bool status)
    {
        onTeam[i] = status;
    }
}
