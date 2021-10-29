using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{ 
    [SerializeField] float minSpawnDelay = 1f;
    [SerializeField] float maxSpawnDelay = 5f;
    [SerializeField] Zombie[] zombiePrefabArray;

    bool spawn = true;

    IEnumerator Start()
    {
        while (spawn)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnDelay, maxSpawnDelay));
            SpawnZombie();
        }
    }

    private void SpawnZombie()
    {
        var zombieIndex = Random.Range(0, zombiePrefabArray.Length);
        Spawn(zombiePrefabArray[zombieIndex]);
    }

    private void Spawn (Zombie myZombie)
    {
        Zombie newZombie = Instantiate(myZombie, transform.position, transform.rotation) as Zombie;
        newZombie.transform.parent = transform;
    }
   

    public void StopSpawn()
    {
        spawn = false;
    }
}
