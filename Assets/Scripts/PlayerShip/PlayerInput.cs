using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    InputActionAsset inputActionAsset;

    [SerializeField]
    public InputActionReference moveDirectionInput, fireInput;

    public event Action FireAction;

    public Vector2 MoveDirection { get; private set; }
    public Vector3 PointerPosition { get; private set; }

    private void OnEnable()
    {
        SetActionMap(true);
        fireInput.action.started += OnFireStarted;
    }

    private void OnDisable()
    {
        SetActionMap(false);
        fireInput.action.started -= OnFireStarted;
    }

    private void Update()
    {
        GetDirection();
        GetPointerPosition();
    }

    private void GetDirection()
    {
        MoveDirection = moveDirectionInput.action.ReadValue<Vector2>();
    }

    private void GetPointerPosition()
    {
        PointerPosition = Pointer.current.position.ReadValue();
    }

    private void OnFireStarted(InputAction.CallbackContext ctx) => FireAction?.Invoke();

    private void SetActionMap(bool state)
    {
        foreach(var map in inputActionAsset.actionMaps)
        {
            if (state)
                map.Enable();
            else
                map.Disable();
        }
    }
}
