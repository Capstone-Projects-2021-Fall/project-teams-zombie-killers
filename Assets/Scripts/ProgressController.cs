using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressController : MonoBehaviour
{

    [SerializeField] float waitToLoad = 4f;  
    [SerializeField] GameObject winLabel;
    [SerializeField] GameObject loseLabel;
    int numbOfZombies = 0;
    bool levelTimerFinished = false;

    public void Start()
    {
        winLabel.SetActive(false);
        loseLabel.SetActive(false);
    }

   public void ZombieSpawned()
    {
        numbOfZombies++;
    }

    public void ZombieKilled()
    {
        numbOfZombies--;
        if (numbOfZombies <= 0 && levelTimerFinished)
        {
            StartCoroutine(HandleWinCondition());
         
        }
    }

    IEnumerator HandleWinCondition()
    {
        winLabel.SetActive(true);
        GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(waitToLoad);
        FindObjectOfType<ScreenLoad>().LoadNextScene();
    }

    public void HandleLoseCondition()
    {
        loseLabel.SetActive(true);
        Time.timeScale = 0;
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
