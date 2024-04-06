using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    [SerializeField] PlayerController player;
    [SerializeField] CinemachineBrain cameraBrain;
    private Vector3 inputVector = new Vector3();

    // Update is called once per frame
    void Update()
    {
        inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), Input.GetAxis("Sprint"));
        player.sprint(inputVector.z);
        player.movePlayer(inputVector);
    }

    private void OnDisable()
    {
        cameraBrain.enabled = false;
    }

    private void OnEnable()
    {
        cameraBrain.enabled = true;
    }
}
