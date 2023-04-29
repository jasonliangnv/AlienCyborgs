using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Bool check if enemy is first boss
    public bool firstBoss = false;

    // Enemy HP
    private int health;
    private int mhealth;
    // Start is called before the first frame update
    void Start()
    {
        if(firstBoss)
        {
            mhealth = 20;
        }
        else
        {
            mhealth = 3;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (mhealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            mhealth--;
        }
    }
}
