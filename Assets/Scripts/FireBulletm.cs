using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletm : MonoBehaviour
{
    // Camera
    public Camera cam;

    // Fire Point
    public Transform firePoint;

    //Bullet Prefab
    public GameObject bulletPrefab;

    // Mouse World Position
    Vector3 mousePos;

    // Direction the bullet fires in
    Vector3 fireDir;

    // Initial direction and position of the bullet
    Vector3 initialPosition;
    Quaternion initialRotation;

    // Variables for buffered firing
    float fireTimer = 0;
    bool onCooldown = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Updates mouse world position
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButton(0))
        {
            if (!onCooldown)
            {
                Fire();
                onCooldown = true;
            }
        }

        if (onCooldown)
            fireTimer += Time.deltaTime;
        if (fireTimer > 0.5)
        {
            fireTimer = 0;
            onCooldown = false;
        }


    }

    private void FixedUpdate()
    {
        fireDir = mousePos - firePoint.position;
        float angle = Mathf.Atan2(fireDir.y, fireDir.x) * Mathf.Rad2Deg - 90f;
        firePoint.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * 10f, ForceMode2D.Impulse);
    }
}