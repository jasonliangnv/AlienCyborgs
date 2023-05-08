using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Enemy HP
    public int health;

    public bool isBoss = false;
    
    public GameObject canvas;

    private GameObject healthBar;

    void Start()
    {
        if(isBoss)
        {
            canvas = Instantiate(canvas);
            canvas.SetActive(true);
            healthBar = GameObject.Find("HealthBar");
            healthBar.SetActive(true);
            healthBar.GetComponent<EnemyHealthBar>().SetMaxHealth(health);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            if(isBoss)
            {
                Destroy(canvas);
            }
            
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health--;

            if(isBoss)
            {
                healthBar.GetComponent<EnemyHealthBar>().SetHealth(health);
            }
        }
    }
}
