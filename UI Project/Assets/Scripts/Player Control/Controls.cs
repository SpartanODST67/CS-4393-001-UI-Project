using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ControlKeys { UP, LEFT, DOWN, RIGHT, SPRINT, INTERACT, INVENTORY, PAUSE};

[CreateAssetMenu(menuName = "ScriptableObjects/Controls")]
public class Controls : ScriptableObject
{
    public List<KeyCode> keys = new List<KeyCode>();
}
