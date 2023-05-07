using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Enemy HP
    public int health;

    public bool isBoss = false;
    
    private GameObject healthBar;

    void Start()
    {
        if(isBoss)
        {
            healthBar = GameObject.Find("BossHealthBar");
            healthBar.SetActive(true);
            healthBar.GetComponent<EnemyHealthBar>().SetMaxHealth(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            healthBar.SetActive(false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;
            healthBar.GetComponent<EnemyHealthBar>().SetHealth(health);
        }
    }
}
