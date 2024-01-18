using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    private float defaultMovementSpeed;
    [SerializeField] float movementThreshold = 0.1f;
    [SerializeField] float sprintThreshold = 0.1f;
    [SerializeField] bool isSprinting = false;

    [SerializeField] float turnSmoothTime = 0.1f;
    private float turnVelocity;

    [SerializeField] Transform cam;

    [SerializeField] Vector3 origin;

    private CharacterController characterController;
    private StateManager stateManager;

    // Start is called before the first frame update
    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        characterController = GetComponent<CharacterController>();
        stateManager = GameObject.Find("Movement State Manager").GetComponent<StateManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stateManager.getState() == StateManager.MovementState.Wandering)
        {
            sprint();
            movePlayer();
        }
    }

    private void sprint()
    {
        float sprintInput = Input.GetAxis("Sprint");
        if (sprintInput >= sprintThreshold && !isSprinting)
        {
            movementSpeed *= 2f;
            isSprinting = true;
        }
        else
        {
            movementSpeed = defaultMovementSpeed;
            isSprinting = false;
        }
    }

    // Moves the player to input.
    private void movePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        //This moves player when an input button is pressed.
        if (direction.magnitude >= movementThreshold)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity, turnSmoothTime);
            Vector3 moveDirection = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            characterController.Move(moveDirection * movementSpeed * Time.deltaTime);
        }

        //This applies "gravity" to stick player to ground.
        characterController.SimpleMove(Vector3.down * Time.deltaTime);
    }
}
