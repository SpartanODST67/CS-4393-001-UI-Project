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
        player.Sprint(inputVector.z);
        player.MovePlayer(inputVector);
    }

    private void OnDisable()
    {
        if (cameraBrain != null)
        {
            cameraBrain.enabled = false;
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
