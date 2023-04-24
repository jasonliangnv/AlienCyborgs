using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementm : MonoBehaviour
{
    // Public movespeed
    public float moveSpeed = 1f;
    // Characters animator
    //public Animator animator;
    // Direction sprites
    public Sprite moveUp;
    public Sprite moveDown;
    public Sprite moveRight;
    public Sprite moveLeft;
    public Sprite lookRightUp;
    public Sprite lookLeftUp;
    private bool isPaused;
    // Private varibles

    // Players RigidBody
    Rigidbody2D rb;

    // Vector2 to store movement
    Vector2 movement;

    // Character sprite component
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component from the player gameobject
        rb = GetComponent<Rigidbody2D>();

        // Get sprite render component
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Set the Z-coordinate to zero

        // Movement for A and D left right movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // Movement for W and S up down movement
        movement.y = Input.GetAxisRaw("Vertical");

        // Animator settings for later use

        //animator.SetFloat("Horizontal" , movement.x);
        //animator.SetFloat("Vertical", movement.y);
        //animator.SetFloat("Speed", movement.sqrMagnitude);
       

       
       
        // Calculate mouse angle and change out sprite accordingly
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > -45f && angle <= 22f)
        {
            spriteRenderer.sprite = moveRight;
        }
        else if (angle > 22f && angle <= 50f)
        {
            spriteRenderer.sprite = lookRightUp;
        }
        else if (angle > 50f && angle <= 112.5f)
        {
            spriteRenderer.sprite = moveUp;
        }
        else if (angle > 112.5f && angle <= 158f)
        {
            spriteRenderer.sprite = lookLeftUp;
        }
        else if (angle > 158f || angle <= -135f)
        {
            spriteRenderer.sprite = moveLeft;
        }
        else
        {
            spriteRenderer.sprite = moveDown;
        }
        
      
    }
    private void FixedUpdate()
    {
        // Changes the players rigidbody based on previous vector movements, multiplies by Time.fixedDeltaTime for smooth movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
