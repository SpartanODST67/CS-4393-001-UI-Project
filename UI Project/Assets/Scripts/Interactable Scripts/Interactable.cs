using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    public string interactionPrompt { get; }
    public bool Interact(Interactor interactor);
}
