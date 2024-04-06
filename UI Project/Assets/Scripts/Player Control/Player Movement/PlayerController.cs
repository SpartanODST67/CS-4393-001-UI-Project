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

    // Start is called before the first frame update
    void Start()
    {
        defaultMovementSpeed = movementSpeed;
        characterController = GetComponent<CharacterController>();
    }

    // Moves the player to input.
    public void movePlayer(Vector3 input)
    {
        float horizontalInput = input.x;
        float verticalInput = input.y;
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

    //Increases player's speed if the sprint button is pressed.
    public void sprint(float input)
    {
        if (input >= sprintThreshold && !isSprinting)
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
}
