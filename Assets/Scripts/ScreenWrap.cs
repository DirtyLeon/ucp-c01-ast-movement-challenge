using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Rigidbody rb;

    private void Awake()
    {
        if(rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void Reposition(Vector2 min, Vector2 max)
    {
        var currentPosition = transform.position;
        var desiredPosition = Vector3.zero;

        desiredPosition.x =
            (currentPosition.x < min.x) ? max.x :
            (currentPosition.x > max.x) ? min.x :
            currentPosition.x;

        desiredPosition.y =
            (currentPosition.y < min.y) ? max.y :
            (currentPosition.y > max.y) ? min.y :
            currentPosition.y;

        desiredPosition.z = currentPosition.z;

        rb.MovePosition(desiredPosition);
    }
}
