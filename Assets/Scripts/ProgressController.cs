using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{

    int numbOfZombies = 0;
    bool levelTimerFinished = false;

   public void ZombieSpawned()
    {
        numbOfZombies++;
    }

    public void ZombieKilled()
    {
        numbOfZombies--;
        if (numbOfZombies <= 0 && levelTimerFinished)
        {
            Debug.Log("End level now");
        }
    }

    public void LevelFinished()
    {
        levelTimerFinished = true;
        StopSpawner();
    }

    private void StopSpawner()
    {
        ZombieSpawner[] spawnerArray = FindObjectsOfType<ZombieSpawner>();
        foreach (ZombieSpawner spawner in spawnerArray)
        {
            spawner.StopSpawn();
        }
    }
}
