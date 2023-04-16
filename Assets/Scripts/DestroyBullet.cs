using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<<< Updated upstream:Assets/Scripts/EnemyScripts/EnemyController.cs
public class EnemyController : MonoBehaviour
{
    // Enemy HP
    int health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }

========
public class DestroyBullet : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 2f);
    }

>>>>>>>> Stashed changes:Assets/Scripts/DestroyBullet.cs
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")    
            health -= 1;
    }
}
