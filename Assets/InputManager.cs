using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Inputs inputs;

    private void Awake()
    {
        inputs = new Inputs();
    }

    private void OnEnable()
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController == null) return;

        inputs.Gameplay.Movement.performed += moveValue =>
        {
            playerController.moveAxis = moveValue.ReadValue<Vector2>();
        };
        inputs.Gameplay.Movement.canceled += moveValue =>
        {
            playerController.moveAxis = moveValue.ReadValue<Vector2>();
        };
        inputs.Gameplay.Jump.performed += jumpValue =>
        {
            playerController.isJumping = jumpValue.ReadValueAsButton();
        };
        inputs.Gameplay.Jump.canceled += jumpValue =>
        {
            playerController.isJumping = jumpValue.ReadValueAsButton();
        };
        inputs.Gameplay.Sprint.performed += sprintValue =>
        {
            playerController.isSprinting = sprintValue.ReadValueAsButton();
        };
        inputs.Gameplay.Sprint.canceled += sprintValue =>
        {
            playerController.isSprinting = sprintValue.ReadValueAsButton();
        };

        inputs.Enable();
    }



    private void OnDisable()
    {
        inputs.Disable();
    }
}
