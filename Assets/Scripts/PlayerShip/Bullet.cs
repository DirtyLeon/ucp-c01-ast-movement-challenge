using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private Rigidbody rb;

    private float existTime = 2f;

    public void Launch(float force)
    {
        rb.AddForce(force * transform.forward);
        StartCoroutine(SelfDestroy());
    }

    IEnumerator SelfDestroy()
    {
        yield return new WaitForSeconds(existTime);
        Destroy(gameObject);
    }
}
