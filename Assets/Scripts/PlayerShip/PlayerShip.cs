using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShip : MonoBehaviour
{
    [SerializeField]
    PlayerInput playerInput;

    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    ShipTurret turret;

    private void Awake()
    {
        playerMovement.Setup();
    }

    private void OnEnable()
    {
        playerInput.fireInput.action.started += OnFireStarted;
    }

    private void OnDisable()
    {
        playerInput.fireInput.action.started -= OnFireStarted;
    }

    private void FixedUpdate()
    {
        var moveDirection = playerInput.MoveDirection;
        playerMovement.Move(moveDirection);
        playerMovement.Tilt(moveDirection);
        turret.Aim(playerInput.PointerPosition);
    }

    private void OnFireStarted(InputAction.CallbackContext ctx)
    {
        turret.Fire();
    }
}
