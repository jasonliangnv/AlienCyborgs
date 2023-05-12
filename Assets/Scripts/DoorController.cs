using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public AudioSource audioSource;
    //public AudioClip keyPressSound;
    public GameObject openTxt;
    public GameObject lockedTxt;
    public bool locked;
    public AnimationClip closeClip;
    public AnimationClip openClip;
    Animator animator;
    private bool canOpen = false;
    private bool doorOpened = false;
    private int doorLayerIndex = -1;
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.enabled = false;
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
            if (doorOpened && canOpen) {
                
                animator.Play(closeClip.name, doorLayerIndex, 0f);
                doorOpened = false;
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
            audioSource.Play();
            animator.enabled = true;
            animator.Play(openClip.name, doorLayerIndex, 0f);
            doorOpened = true;
            openTxt.SetActive(false);
            
        }
    }
}
