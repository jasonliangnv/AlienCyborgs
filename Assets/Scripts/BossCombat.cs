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
    private int attackTracker1 = 0;
    private int attackTracker2 = 0;
    private int attackTracker3 = 0;
    private int totalHealth = 0;

    private void Start()
    {
        // Grabs the enemy total HP
        totalHealth = GetComponent<EnemyHealth>().health;
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
            if (attackTracker1 < 10)
            {
                fireRate = 2f;
                attackTracker1++;
                attackTracker2++;
                attackTracker3++;
            }
            // Fires a special fast bullet every 10 attacks and when HP is below 90%
            else if (attackTracker1 >= 2 && ((float)GetComponent<EnemyHealth>().health/totalHealth)*100 <= 90)
            {
                bulletSpeed = 5f;

                FireRandomBullet();
                
                bulletSpeed = 0.5f;
                attackTracker1 = 0;
            }
            
            // Fires special attacks at 80% HP or below
            if(attackTracker2 >= 10 && ((float)GetComponent<EnemyHealth>().health/totalHealth)*100 <= 80)
            {
                bulletSpeed = 10f;
                FireTripleBullet();

                bulletSpeed = 0.5f;
                attackTracker2 = 0;
            }

            
            // Fires special attacks at 60% HP or below
            if(attackTracker3 >= 5 && ((float)GetComponent<EnemyHealth>().health/totalHealth)*100 <= 60)
            {
                GetComponent<EnemyAiController>().speed = 1.5f;
                bulletSpeed = 0f;

                BulletMine();

                bulletSpeed = 0.5f;
                attackTracker3 = 0;
            }

            // Cranks the speed up near death
            if(((float)GetComponent<EnemyHealth>().health/totalHealth)*100 <= 10)
            {
                GetComponent<EnemyAiController>().speed = 5;
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

    void FireRandomBullet()
    {
        Vector3 direction = (playerTransform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))) - transform.position;
        direction.Normalize();
        GameObject bullet = Instantiate(bulletPrefab, EnemyFirePoint.position, EnemyFirePoint.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;        
    }

    // Fires a diamond bullet mine based on the enemies location
    void BulletMine()
    {
        Vector3 direction = transform.position + new Vector3(0, 1, 0);
        direction.Normalize();
        GameObject bullet1 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(0, 1, 0), EnemyFirePoint.rotation);
        bullet1.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(0.5f, 0.5f, 0);
        direction.Normalize();
        GameObject bullet2 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(0.5f, 0.5f, 0), EnemyFirePoint.rotation);
        bullet2.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(1, 0, 0);
        direction.Normalize();
        GameObject bullet3 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(1, 0, 0), EnemyFirePoint.rotation);
        bullet3.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(1, -0.5f, 0);
        direction.Normalize();
        GameObject bullet4 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(0.5f, -0.5f, 0), EnemyFirePoint.rotation);
        bullet4.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(0, -1, 0);
        direction.Normalize();
        GameObject bullet5 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(0, -1, 0), EnemyFirePoint.rotation);
        bullet5.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(-0.5f, -0.5f, 0);
        direction.Normalize();
        GameObject bullet6 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(-0.5f, -0.5f, 0), EnemyFirePoint.rotation);
        bullet6.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(-1, 0, 0);
        direction.Normalize();
        GameObject bullet7 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(-1, 0, 0), EnemyFirePoint.rotation);
        bullet7.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;

        direction = transform.position + new Vector3(0.5f, -0.5f, 0);
        direction.Normalize();
        GameObject bullet8 = Instantiate(bulletPrefab, EnemyFirePoint.position + new Vector3(-0.5f, 0.5f, 0), EnemyFirePoint.rotation);
        bullet8.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
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
