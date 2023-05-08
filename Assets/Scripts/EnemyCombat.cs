using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform playerTransform;
    public Transform EnemyFirePoint;
    public int enemyType = 1;
    // Direction the bullet fires in
    Vector3 fireDir;


    // Initial direction and position of the bullet
    Vector3 initialPosition;
    Quaternion initialRotation;

    public float bulletSpeed;
    public float fireRate;

    private float timeSinceLastFire = 0f;

    private void Start()
    {
        if(enemyType == 1)
        {
            fireRate = Random.Range(0.1f, 0.3f);
        }
        else if(enemyType == 2)
        {
            fireRate = Random.Range(0.1f, 0.5f);
        }
        else if(enemyType == 3)
        {
            fireRate = 2;
        }
        
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastFire += Time.deltaTime;
        if (timeSinceLastFire >= (1f / fireRate) && enemyType == 1)
        {
            FireBullet();
            timeSinceLastFire = 0f;
        }
        else if(timeSinceLastFire >= (1f / fireRate) && enemyType == 2)
        {
            FireTripleBullet();
            timeSinceLastFire = 0f;
        }
        else if(timeSinceLastFire >= (1f / fireRate) && enemyType == 3)
        {
            FireRandomBullet();
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

    void FireRandomBullet()
    {
        Vector3 direction = (playerTransform.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), Random.Range(-1f, 1f))) - transform.position;
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
