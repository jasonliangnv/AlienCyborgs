using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthBarObj;
    public SpriteRenderer sprite;
    
    private int maxHealth;
    private int curHealth;
    private float timer;
    private float invulFrame;
  
    HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthBarObj.GetComponent<HealthBar>();
        maxHealth = 6;
        curHealth = maxHealth;
        timer = 0f;
        invulFrame = 0.25f;
    }

    void Update()
    {
        if (timer >= 0)
        {
            timer -= Time.deltaTime;
        }
    }

   public void TakeDamage()
    {
        if(timer <= 0)
        {
            timer = invulFrame;
            curHealth--;
            healthBar.updateHealth();
            StartCoroutine(FlashDamage());
        }
    }

    public IEnumerator FlashDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sprite.color = Color.white;
    }
}
