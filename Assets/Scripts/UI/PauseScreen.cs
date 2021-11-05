using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PauseScreen : MonoBehaviour
{
    public static PauseScreen singleton;

    public GameObject[] zombieSpawners;

    private void Start()
    {
        if (singleton != null && singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            singleton = this;
        }
    }

    private void OnEnable()
    {
        Time.timeScale = 0;
        //DOTween.PauseAll();
        //foreach(GameObject zombieSpawner in zombieSpawners)
        //{
        //    zombieSpawner.GetComponent<ZombieSpawner>().PauseSpawn();
        //}
    }

    private void OnDisable()
    {
        Time.timeScale = 1;
        //DOTween.PlayAll();
        //foreach (GameObject zombieSpawner in zombieSpawners)
        //{
        //    zombieSpawner.GetComponent<ZombieSpawner>().ResumeSpawn();
        //}
    }
}
