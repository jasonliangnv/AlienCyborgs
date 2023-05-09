using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickups : MonoBehaviour
{
    public GameObject itemHighlight;
    public GameObject pickUpTxt;
    public GameObject spawner;
    public GameObject[] doors;

    public bool isTrigger;

    int numOfDoors;
    private void Start()
    {
        numOfDoors = doors.Length;
    }
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
            if (doors == null)
            {
                Destroy(this.gameObject);
            }
            for (int i = 0; i < numOfDoors; i++)
            {
                doors[i].SetActive(true);
                doors[i].GetComponent<DoorController>().locked = false;
            }
            
            if (isTrigger)
            {
                spawner.GetComponent<EnemySpawner>().running = true;
            }
            Destroy(this.gameObject);
        }
    }
}
