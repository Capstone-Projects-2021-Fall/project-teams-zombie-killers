using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    public GameObject zombiePrefab;

    [SerializeField] private float spawnRate; // delay between zombie spawns (in seconds)
    [SerializeField] private int totalZombies; // could (should) replace this variable later when we introduce different types of zombies
    [SerializeField] private int activeSpawnerIndex; // used to keep track of which row the zombie spawns in

    void Awake()
    {
        activeSpawnerIndex = 0;
        StartCoroutine(SpawnZombie());
    }

    IEnumerator SpawnZombie()
    {
        while (totalZombies != 0)
        {
            activeSpawnerIndex = Random.Range(0, 5);  // randomizes the spawn location
            yield return new WaitForSeconds(spawnRate);
            Instantiate(zombiePrefab, transform.GetChild(activeSpawnerIndex));
            totalZombies--;
        }
    }
}
