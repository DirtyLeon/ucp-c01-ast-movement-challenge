using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShip : MonoBehaviour
{
    public PlayerInput playerInput;

    [SerializeField]
    PlayerMovement playerMovement;

    [SerializeField]
    ShipTurret turret;

    private void OnEnable()
    {
        playerInput.FireAction += OnFire;
    }

    private void OnDisable()
    {
        playerInput.FireAction -= OnFire;
    }

    private void FixedUpdate()
    {
        var moveDirection = playerInput.MoveDirection;
        playerMovement.Move(moveDirection);
        playerMovement.Tilt(moveDirection);
        turret.Aim(playerInput.PointerPosition);
    }

    public void OnFire() => turret.Fire();
}
