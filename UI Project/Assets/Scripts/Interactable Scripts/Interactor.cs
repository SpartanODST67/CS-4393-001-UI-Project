using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [Header("Interactor Settings")]
    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionRadius;
    [SerializeField] LayerMask interactionLayerMask;
    public InteractionPromptUI interactionPromptUI;
    [SerializeField] InputHandler inputHandler;
    private bool hasInteractionPrompt = false;

    [Header("Debug Info")]
    private Collider[] overlappingInteractions = new Collider[3];
    [SerializeField] int interactionsFound = 0;

    private Interactable interactable;

    private void Update()
    {
        if(interactionPromptUI == null)
        {
            interactionPromptUI = FindAnyObjectByType<InteractionPromptUI>();
        }
        if (inputHandler.gameObject.activeInHierarchy)
        {
            FindInteractables();
        }
    }

    private void FindInteractables()
    {
        interactionsFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionRadius, overlappingInteractions, interactionLayerMask);

        if(interactionsFound > 0)
        {
            InteractablesFound();
        }
        else
        {
            InteractablesNotFound();
        }
    }

    private void InteractablesFound()
    {
        interactable = overlappingInteractions[0].GetComponent<Interactable>();

        if(interactable != null)
        {
            if(!interactionPromptUI.IsActive() && inputHandler.gameObject.activeInHierarchy)
            {
                interactionPromptUI.Open(interactable.interactionPrompt);
            }

            if(inputHandler.GetInteract() >= 0.1f)
            {
                interactionPromptUI.Close();
                interactable.Interact(this);
            }
        }
    }

    private void InteractablesNotFound()
    {
        if(interactable != null)
        {
            interactable = null;
        }
        if (interactionPromptUI.IsActive())
        {
            interactionPromptUI.Close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
