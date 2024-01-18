using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] Transform interactionPoint;
    [SerializeField] float interactionRadius;
    [SerializeField] LayerMask interactionLayerMask;
    public InteractionPromptUI interactionPromptUI;
    private bool hasInteractionPrompt = false;

    private Collider[] overlappingInteractions = new Collider[3];
    [SerializeField] int interactionsFound = 0;

    private Interactable interactable;
    private StateManager stateManager;

    private void Start()
    {
        stateManager = FindObjectOfType<StateManager>();
    }

    private void Update()
    {
        if(interactionPromptUI == null)
        {
            interactionPromptUI = FindAnyObjectByType<InteractionPromptUI>();
        }
        if (stateManager.getState() == StateManager.MovementState.Wandering)
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
            if(!interactionPromptUI.isActive() && stateManager.getState() == StateManager.MovementState.Wandering)
            {
                interactionPromptUI.open(interactable.interactionPrompt);
            }

            if(Input.GetAxis("Interact") >= 0.1f)
            {
                interactionPromptUI.close();
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
        if (interactionPromptUI.isActive())
        {
            interactionPromptUI.close();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interactionPoint.position, interactionRadius);
    }
}
