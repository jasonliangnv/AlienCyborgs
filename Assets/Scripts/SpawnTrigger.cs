using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public EnemySpawner spawner;
    bool hasTriggered;

    // Start is called before the first frame update
    void Start()
    {
        hasTriggered = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(!hasTriggered && other.CompareTag("Player"))
        {
            hasTriggered = true;
            spawner.running = true;
        }
    }
}
