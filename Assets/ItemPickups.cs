using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    public GameObject itemHighlight;
    public GameObject pickUpTxt;
    public GameObject spawner;
    public GameObject door;

    public bool isTrigger;

    private bool canPickUp = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = true;
            itemHighlight.SetActive(true);
            pickUpTxt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canPickUp = false;
            itemHighlight.SetActive(false);
            pickUpTxt.SetActive(false);
        }
    }
    private void Update()
    {
        if (canPickUp && Input.GetKeyDown(KeyCode.E))
        {
            door.SetActive(true);
            door.GetComponent<DoorController>().locked = false;
            if (isTrigger)
            {
                spawner.GetComponent<EnemySpawner>().running = true;
            }
            Destroy(gameObject);
        }
    }
}
