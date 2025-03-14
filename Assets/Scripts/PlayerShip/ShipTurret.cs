using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ShipTurret : MonoBehaviour
{
    [SerializeField]
    Transform turretTransform;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Bullet bulletPrefab;

    [SerializeField]
    float LaunchForce = 100f;

    private Transform bulletAnchor;

    private void Awake()
    {
        bulletAnchor = GameObject.Find("BulletAnchor").transform;
    }

    public void Aim()
    {
        var pointerPos = Pointer.current.position.ReadValue();
        var worldPos = Camera.main.ScreenToWorldPoint(new Vector3(pointerPos.x, pointerPos.y, Camera.main.nearClipPlane));

        turretTransform.LookAt(new Vector3(worldPos.x, worldPos.y, turretTransform.position.z), Vector3.back);
    }

    public void Aim(Vector3 target)
    {
        var targetPos = Camera.main.ScreenToWorldPoint(new Vector3(target.x, target.y, Camera.main.nearClipPlane));
        var fixedPos = new Vector3(targetPos.x, targetPos.y, turretTransform.position.z);
        turretTransform.LookAt(fixedPos, Vector3.back);
    }

    public void Fire()
    {
        var bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation, bulletAnchor);
        bullet.Launch(LaunchForce);
    }
}
