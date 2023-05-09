using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip keyPressSound;
    public GameObject openTxt;
    public GameObject lockedTxt;
    public bool locked = false;

    private bool canOpen = false;
    private bool doorOpend = false;

    void Start()
    {
        //audioSource = gameObject.AddComponent<AudioSource>();
        //audioSource.playOnAwake = false;
        //audioSource.clip = keyPressSound;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (locked)
            {
                lockedTxt.SetActive(true);
                canOpen = false;
            }
            else if (!locked)
            {
                canOpen = true;
                openTxt.SetActive(true);
            }
          
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (doorOpend) {

                SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

                // Turn off the SpriteRenderer component
                spriteRenderer.enabled = true;

                // Get the GameObject's Collider component
                Collider2D collider = gameObject.GetComponent<Collider2D>();

                // Turn off the Collider component
                collider.enabled = true;

                doorOpend = false;
            }
            canOpen = false;
            openTxt.SetActive(false);
            lockedTxt.SetActive(false);
        }
    }
    private void Update()
    {
        if (canOpen && !locked && Input.GetKeyDown(KeyCode.E))
        {
            SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

            // Turn off the SpriteRenderer component
            spriteRenderer.enabled = false;

            // Get the GameObject's Collider component
            Collider2D collider = gameObject.GetComponent<Collider2D>();

            // Turn off the Collider component
            collider.enabled = false;

            doorOpend = true;
            openTxt.SetActive(false);
        }
        
        if(canOpen && Input.GetKeyDown(KeyCode.E))
        {
            audioSource.Play();
        }
    }
}
