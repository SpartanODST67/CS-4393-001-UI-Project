using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] AnimationController playerAnimator; 
    [SerializeField] CinemachineBrain cameraBrain;
    [SerializeField] Controls controls;
    [SerializeField] MenuManager menuManager;
    private Vector3 inputVector = new Vector3();
    private float horizontalInput;
    private float verticalInput;
    private float sprintInput;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(controls.keys[(int) ControlKeys.INVENTORY]))
        {
            menuManager.ActivateInventory(2);
            gameObject.SetActive(false);
            return;
        }
        if (Input.GetKey(controls.keys[(int) ControlKeys.LEFT]))
        {
            horizontalInput = -1;
        }
        else if (Input.GetKey(controls.keys[(int) ControlKeys.RIGHT]))
        {
            horizontalInput = 1;
        }

        if (Input.GetKey(controls.keys[(int)ControlKeys.UP]))
        {
            verticalInput = 1;
        }
        else if(Input.GetKey(controls.keys[(int)ControlKeys.DOWN]))
        {
            verticalInput = -1;
        }

        if (Input.GetKey(controls.keys[(int)ControlKeys.SPRINT]))
        {
            sprintInput = 1;
        }

        if(horizontalInput != 0 || verticalInput != 0)
        {
            playerAnimator.Walk();
        }
        else
        {
            playerAnimator.Stand();
        }
        inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Sprint"));
        inputVector = new Vector3(horizontalInput, verticalInput, sprintInput);
        player.Sprint(inputVector.z);
        player.MovePlayer(inputVector);
        horizontalInput = 0;
        verticalInput = 0;
        sprintInput = 0;
    }

    public float GetInteract()
    {
        float interactInput = 0;
        if (Input.GetKey(controls.keys[(int) ControlKeys.INTERACT]))
        {
            interactInput = 1;
        }
        return interactInput;
    }

    private void OnDisable()
    {
        if (cameraBrain != null)
        {
            cameraBrain.enabled = false;
        }
        if(playerAnimator != null)
        {
            playerAnimator.Stand();
        }
    }

    private void OnEnable()
    {
        if (cameraBrain != null)
        {
            cameraBrain.enabled = true;
        }
    }
}

