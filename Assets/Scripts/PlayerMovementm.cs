using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementm : MonoBehaviour
{
    // Public movespeed
    public float moveSpeed = 1f;


    // Private varibles

    // Players RigidBody
    Rigidbody2D rb;

    // Vector2 to store movement
    Vector2 movement;

    // Start is called before the first frame update
    void Start()
    {
        // Get the rigidbody component from the player gameobject
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Movement for A and D left right movement
        movement.x = Input.GetAxisRaw("Horizontal");

        // Movement for W and S up down movement
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        // Changes the players rigidbody based on previous vector movements, multiplies by Time.fixedDeltaTime for smooth movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
