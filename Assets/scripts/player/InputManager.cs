using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
#pragma warning disable 649
    public InputActions playerInput;

    private PlayerMotor motor;
    private PlayerLook look;
   
    // Start is called before the first frame update
    void Awake()
    {
        playerInput = new InputActions();

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        playerInput.OnFoot.Crouch.performed += ctx => motor.Crouch();

        playerInput.OnFoot.Jupming.performed += ctx => motor.Jump();
        playerInput.OnFoot.Sprint.performed += ctx => motor.Sprint();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        motor.ProcessMove(playerInput.OnFoot.Movement.ReadValue<Vector2>());
    }

    private void LateUpdate()
    {
        look.ProcessLook(playerInput.OnFoot.Look.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        playerInput.OnFoot.Enable();
    }

    private void OnDisable()
    {
        playerInput.OnFoot.Disable();
    }
}
