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
            Instantiate(canvas);
            canvas.SetActive(true);
            healthBar = GameObject.Find("HealthBar");
            Debug.Log("done");
            healthBar.SetActive(true);
            Debug.Log("done");
            healthBar.GetComponent<EnemyHealthBar>().SetMaxHealth(health);
            Debug.Log("done");
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
