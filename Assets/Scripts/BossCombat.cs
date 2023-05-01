using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCombat : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public Transform EnemyFirePoint;
    // Direction the bullet fires in
    Vector3 fireDir;


    // Initial direction and position of the bullet
    Vector3 initialPosition;
    Quaternion initialRotation;

    public float bulletSpeed;
    public float fireRate;

    private float timeSinceLastFire = 0f;

    // Checks how many normal attacks the boss has made
    private int attackTracker = 0;

    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire >= (1f / fireRate))
        {
            FireBullet();
            timeSinceLastFire = 0f;

            // Different fire rate changes for bosses vs regular enemies
            if (attackTracker < 10)
            {
                fireRate = 5f;
                attackTracker++;
            }
            // Fires a special fast bullet every 10 attacks
            else if (attackTracker == 10)
            {
                bulletSpeed = 10f;
                FireTripleBullet();

                bulletSpeed = 1f;
                attackTracker = 0;
            }
        }
    }
    void FireBullet()
    {
        Vector3 direction = playerTransform.position - transform.position;
        direction.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }

    void FireTripleBullet()
    {
        // Saves user position so shotgun spread is more consistent
        Vector3 position = playerTransform.position;

        Vector3 direction = position - transform.position;
        direction.Normalize();
        GameObject bullet1 = Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
        bullet1.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = (position + new Vector3(3, 3, 0)) - transform.position;
        direction.Normalize();
        GameObject bullet2 = Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
        bullet2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = (position + new Vector3(-3, -3, 0)) - transform.position;
        direction.Normalize();
        GameObject bullet3 = Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
        bullet3.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
    }
}
