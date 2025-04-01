using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipTurret : MonoBehaviour
{
    [SerializeField]
    private Transform turretTransform;

    [SerializeField]
    private Transform firePoint;

    [SerializeField]
    private Bullet bulletPrefab;

    [SerializeField]
    private float LaunchForce = 100f;

    private Transform bulletAnchor;

    private void Awake()
    {
        bulletAnchor = GameObject.Find("BulletAnchor").transform;
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
