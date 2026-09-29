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
        Debug.Log("TIR OK");

        if (bulletPrefab == null || muzzlePoint == null)
        {
            Debug.LogWarning("Bullet Prefab ou Muzzle Point manquant.");
            return;
        }

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