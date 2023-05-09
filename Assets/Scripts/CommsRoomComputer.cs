using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommsRoomComputer : MonoBehaviour
{
    public GameObject screenHighlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            screenHighlight.SetActive(true);
            
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            screenHighlight.SetActive(false);
            
        }
    }
}
