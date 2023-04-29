using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerHealth>().TakeDamage();
            Destroy(gameObject);
        }
        else if(collision.CompareTag("Enemy"))
        {
            // This is just here so enemies aren't hit by their own bullets
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
