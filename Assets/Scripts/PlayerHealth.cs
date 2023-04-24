using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int maxHealth;
    private int curHealth;

    public GameObject healthBarObj;

    HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthBarObj.GetComponent<HealthBar>();
        maxHealth = 6;
        curHealth = maxHealth;
    }

   public void TakeDamage()
    {
        curHealth--;
        healthBar.updateHealth();
    }
}
