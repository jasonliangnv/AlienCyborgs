using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public Transform EnemyFirePoint;
    // Direction the bullet fires in
    Vector3 fireDir;

    // Initial direction and position of the bullet
    Vector3 initialPosition;
    Quaternion initialRotation;

    public float bulletSpeed = 10f;
    public float fireRate = 1f;

    private float timeSinceLastFire = 0f;

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire >= 1f / fireRate)
        {
            FireBullet();
            timeSinceLastFire = 0f;
        }
    }
    void FireBullet()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}