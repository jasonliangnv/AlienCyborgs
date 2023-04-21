using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
  
    public GameObject openTxt;

    private bool canOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = true;
            openTxt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canOpen = false;
            openTxt.SetActive(false);
        }
    }
    private void Update()
    {
        if (canOpen && Input.GetKeyDown(KeyCode.E))
        {
            Destroy(gameObject);
        }
    }
}
