using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform muzzlePoint;

    public float bulletSpeed = 15f;
    public float bulletLifetime = 5f;
    public bool useGravity = true;

    public void Shoot()
    {
        if (bulletPrefab == null || muzzlePoint == null)
            return;

        GameObject bullet = Instantiate(
            bulletPrefab,
            muzzlePoint.position,
            muzzlePoint.rotation
        );

        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.useGravity = useGravity;
            rb.linearVelocity = muzzlePoint.forward * bulletSpeed;
        }

        Destroy(bullet, bulletLifetime);
    }
}