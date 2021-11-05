using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{

    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Zombie[] zombiePrefabArray;

    private bool isPaused = false;
    private bool isFirstWave = true;

    private void Start()
    {
        StartCoroutine(StartSpawn());
    }

    IEnumerator StartSpawn()
    {
        while (true)
        {
            while (isPaused)
            {
                yield return null;
            }
            if (isFirstWave)
            {
                yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
                isFirstWave = false;
            }
            SpawnZombie();
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
        }
    }

    private void SpawnZombie()
    {
        var zombieIndex = Random.Range(0, zombiePrefabArray.Length);
        Zombie newZombie = Instantiate(zombiePrefabArray[zombieIndex], transform.position, transform.rotation) as Zombie;
        newZombie.transform.parent = transform;
    }

    public void PauseSpawn()
    {
        isPaused = true;
    }

    public void ResumeSpawn()
    {
        isPaused = false;
    }
}
