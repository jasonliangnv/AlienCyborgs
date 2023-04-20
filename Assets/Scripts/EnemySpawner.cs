using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public List<Transform> spawners;
    public GameObject enemyPrefab;
    public bool spawning;

    // Start is called before the first frame update
    void Start()
    {
        spawning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawning)
        {
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
                
                Instantiate(enemyPrefab, spawners[spawnerIndex].position, Quaternion.identity);
                settingIndex = true;
            }
            spawning = false;
            alreadySpawned.Clear();
        }
    }
}
