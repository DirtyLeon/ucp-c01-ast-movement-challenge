using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    [SerializeField]
    Transform bodyFrame;

    public float movementSpeed = 10f;
    public float bodyRotateDegree = 15f;

    private void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector2 direction)
    {
        Vector3 nextPos = movementSpeed * Time.fixedDeltaTime * direction;
        rb.MovePosition(rb.position + nextPos);
    }

    public void Tilt(Vector2 direction)
    {
        bodyFrame.localEulerAngles = bodyRotateDegree * new Vector3(direction.y, -direction.x, 0);
    }
}
