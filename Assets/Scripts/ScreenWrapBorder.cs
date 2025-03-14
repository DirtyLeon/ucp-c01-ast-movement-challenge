using UnityEngine;

public class ScreenWrapBorder : MonoBehaviour
{
    public Vector2 minAxis, maxAxis;

    private void OnTriggerExit(Collider other)
    {
        var screenWrap = other.GetComponentInParent<ScreenWrap>();

        if (screenWrap != null)
        {
            screenWrap.Reposition(minAxis, maxAxis);
        }
    }
}
