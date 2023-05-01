using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public GameObject healthBarObj;
    public SpriteRenderer sprite;

    private int maxHealth;
    private int curHealth;
    private float timer;
    private float invulFrame;
    private bool alive;
  
    HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = healthBarObj.GetComponent<HealthBar>();
        maxHealth = 6;
        curHealth = maxHealth;
        timer = 0f;
        invulFrame = 0.25f;
        alive = true;
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
        if(timer <= 0 && alive)
        {
            timer = invulFrame;
            curHealth--;
            healthBar.updateHealth();
            StartCoroutine(FlashDamage());
        }

        // Disables player movement on death
        if(curHealth == 0)
        {
            alive = false;

            GetComponent<PlayerMovementm>().enabled = false;
            GetComponent<FireBulletm>().enabled = false;
            
            GameObject armsController = GameObject.Find("PlayerArms");
            armsController.GetComponent<PlayerArmController>().enabled = false;
        }
    }

    public IEnumerator FlashDamage()
    {
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.25f);
        sprite.color = Color.white;
    }
}
