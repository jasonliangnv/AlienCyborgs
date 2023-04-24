using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  
    public GameObject openTxt;
    public GameObject lockedTxt;
    public bool locked = false;

    private bool canOpen = false;
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
            canOpen = false;
            openTxt.SetActive(false);
            lockedTxt.SetActive(false);
        }
    }
    private void Update()
    {
        if (canOpen && !locked && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.SetActive(false);
        }
    }
}
