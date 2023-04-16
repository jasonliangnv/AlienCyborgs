using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Enemy HP
    private int health;
    private int mhealth;
    // Start is called before the first frame update
    void Start()
    {
        mhealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(mhealth == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Bullet")
            {
                mhealth--;
            }
                
    }
}
