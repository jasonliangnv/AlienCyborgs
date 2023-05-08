using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawners;
    public List<GameObject> enemies;
    public List<GameObject> enemyPrefab;
    public List<GameObject> exitDoor;
    public GameObject enterDoor;
    public int minSpawn;
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
            for(int i = 0; i<exitDoor.Count; i++)
            {
                exitDoor[i].SetActive(true);
                exitDoor[i].GetComponent<DoorController>().locked = true;
            }
            enterDoor.SetActive(true);
            enterDoor.GetComponent<DoorController>().locked = true;

            List<int> alreadySpawned = new List<int>();
            int numEnemies = Random.Range(minSpawn, spawners.Count);
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
                
                int enemyIndex = Random.Range(0, enemyPrefab.Count);
                GameObject enemy = Instantiate(enemyPrefab[enemyIndex], spawners[spawnerIndex].position, Quaternion.identity);
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
            for (int i = 0; i < exitDoor.Count; i++)
                exitDoor[i].GetComponent<DoorController>().locked = false;
            enterDoor.SetActive(false);
            currentWave = 0;
        }
    }
}
