using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawners;
    public List<GameObject> enemies;
    public GameObject enemyPrefab;
    public GameObject door;
    public bool running;
    public bool spawning;
    public int currentWave;
    public int numWaves;

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
        currentWave = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
            door.SetActive(true);
            door.GetComponent<DoorController>().locked = true;
            
            List<int> alreadySpawned = new List<int>();
            int numEnemies = Random.Range(3, 9);
            bool settingIndex = true;

            for(int i = 0; i<numEnemies; i++)
            {
                int spawnerIndex=-1;
                while (settingIndex)
                {
                    spawnerIndex = Random.Range(0, spawners.Count);
                    if (!alreadySpawned.Contains(spawnerIndex))
                    {
                        alreadySpawned.Add(spawnerIndex);
                        settingIndex = false;
                    }
                }
                
                GameObject enemy = Instantiate(enemyPrefab, spawners[spawnerIndex].position, Quaternion.identity);
                enemies.Add(enemy);
                settingIndex = true;
            }
            spawning = false;
            alreadySpawned.Clear();
        }

        for(int i = 0; i<enemies.Count; i++)
        {
            if (enemies[i] == null)
            {
                enemies.RemoveAt(i);
            }
        }

        if(enemies.Count == 0 && !spawning && running)
        {
            spawning = true;
            currentWave++;
        }

        if(currentWave > numWaves)
        {
            spawning = false;
            running = false;
            door.GetComponent<DoorController>().locked = false;
            door.SetActive(false);
            currentWave = 0;
        }
    }
}
