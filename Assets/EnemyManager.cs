using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public PlayerController player;
    public GameObject enemy;
    public Transform[] spawnpoints;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoints();
    }

    private void SpawnPoints()
    {
        if (player.Currenthealth <= 0f)
        {
            return;
        }
        int times = Random.Range(0, spawnpoints.Length);

        List<int> usedspawnpoints = new List<int>();

        for (int i = 0; i < times; i++) 
        {
            int spawnpoint = Random.Range(0, spawnpoints.Length);
            if (!usedspawnpoints.Contains<int>(spawnpoint)) 
            {
                usedspawnpoints.Add(spawnpoint);
                Instantiate(enemy, spawnpoints[spawnpoint].position, spawnpoints[spawnpoint].rotation);
            }
            
        }
    }
}
