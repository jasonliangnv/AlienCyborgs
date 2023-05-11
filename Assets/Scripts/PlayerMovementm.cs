using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerMovementm : MonoBehaviour
{
    // Public movespeed
    public float moveSpeed = 1f;
    // Characters animator
    //Animator animator;
    
    // Direction sprites
    public Sprite moveUp;
    public Sprite moveDown;
    public Sprite moveRight;
    public Sprite moveLeft;
    public Sprite lookRightUp;
    public Sprite lookLeftUp;

    public GameObject dashIcon;
    public bool dashing = false;

    // Private varibles
    // variables to buffer dashing
    float dashTimer;
    float dashBuffer = 1.5f;
    bool dashCooldown = false;
    Vector2 dashPosition;
    Vector2 dashIndicator;

    // Players RigidBody
    Rigidbody2D rb;

    // Vector2 to store movement
    Vector2 movement;

    // Character sprite component
    private SpriteRenderer spriteRenderer;

    // Can move bool for tutorial
    public static bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component from the player gameobject
        rb = GetComponent<Rigidbody2D>();
        canMove = true;
        // Get sprite render component
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Set the Z-coordinate to zero

        if (canMove)
        {
            // Movement for A and D left right movement

            movement.x = Input.GetAxisRaw("Horizontal");

            // Movement for W and S up down movement
            movement.y = Input.GetAxisRaw("Vertical");
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
        }
       


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
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        Vector2 dir = new Vector2(direction.x, direction.y);

        if(movement != Vector2.zero)
            dashIndicator = rb.position + movement.normalized * 4;
        else
            dashIndicator = rb.position + dir.normalized * 4;

        if (Input.GetKeyDown(KeyCode.Space) && canMove && (dashTimer >= dashBuffer))
        {
            dashing = true;
            StartCoroutine(FlashInvul());

            if(movement != Vector2.zero)
                dashPosition = dashIndicator;
            else
                dashPosition = dashIndicator;

            // Resets cooldown and hides dash icon
            dashTimer = 0;
            dashCooldown = true;
            dashIcon.SetActive(false);
        }

        if (dashTimer >= dashBuffer)
        {
            // Turns cooldown off and shows the dash icon again
            if(dashCooldown == true)
            {
                StartCoroutine(FlashCD());
                dashCooldown = false;
                dashIcon.SetActive(true);
            }
            // Updates the dash icon
            else
            {
                dashIcon.transform.position = dashIndicator;
            }
        }

        if(dashTimer < dashBuffer)
            dashTimer += Time.deltaTime;

        if(Vector3.Distance(rb.position, dashPosition) <= 0.25f || dashTimer >= 0.6f)
        {
            dashing = false;
        }
        else if(dashing)
        {
            // Dash movement
            rb.position = Vector2.MoveTowards(rb.position, dashPosition, 2.75f * Time.fixedDeltaTime);
        }

    }
    private void FixedUpdate()
    {
        // Changes the players rigidbody based on previous vector movements, multiplies by Time.fixedDeltaTime for smooth movement
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // lets the player know that their dash is back up
    public IEnumerator FlashCD()
    {
        spriteRenderer.color = Color.green;
        yield return new WaitForSeconds(0.25f);
        spriteRenderer.color = Color.white;
    }

    public IEnumerator FlashInvul()
    {
        spriteRenderer.color = Color.yellow;
        yield return new WaitForSeconds(0.6f);
        spriteRenderer.color = Color.white;        
    }
}
