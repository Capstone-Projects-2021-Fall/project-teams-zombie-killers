using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedZombieSpawning : MonoBehaviour
{
    protected class SpawnInfo
    {
        public Zombie ZombiePrefab;
        public float spawnTime;
        public Transform parent;

        public SpawnInfo(Zombie ZombiePrefab, float spawnTime, Transform parent)
        {
            this.ZombiePrefab = ZombiePrefab;
            this.spawnTime = spawnTime;
            this.parent = parent;
        }
    }

    public Zombie[] zombiePrefabArray;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        SpawnInfo[] Tutorial = {

            new SpawnInfo(zombiePrefabArray[0], 0.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 10.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 10.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 15.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 15.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 15.0f, transform.GetChild(4))

        };

        SpawnInfo[] Level1 = {

            new SpawnInfo(zombiePrefabArray[0], 12.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 20.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 24.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 32.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 32.0f, transform.GetChild(1)),

            new SpawnInfo(zombiePrefabArray[0], 45.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 45.0f, transform.GetChild(4)),

            new SpawnInfo(zombiePrefabArray[0], 52.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 52.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 53.5f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 53.5f, transform.GetChild(4)),

            new SpawnInfo(zombiePrefabArray[0], 60.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 60.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 60.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 63.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 63.0f, transform.GetChild(3)),

            new SpawnInfo(zombiePrefabArray[0], 70.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 70.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 70.0f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[0], 73.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 73.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 73.0f, transform.GetChild(4)),

            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(4))

        };


        SpawnInfo[] Level2 = {

            new SpawnInfo(zombiePrefabArray[1], 12.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 20.0f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[1], 24.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[1], 32.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 32.0f, transform.GetChild(1)),

            new SpawnInfo(zombiePrefabArray[0], 45.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 45.0f, transform.GetChild(2)),

            new SpawnInfo(zombiePrefabArray[1], 52.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 52.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 53.5f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[1], 53.5f, transform.GetChild(4)),

            new SpawnInfo(zombiePrefabArray[0], 60.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 60.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 60.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[1], 63.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 63.0f, transform.GetChild(3)),

            new SpawnInfo(zombiePrefabArray[0], 70.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 70.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 70.0f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[0], 73.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 73.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 73.0f, transform.GetChild(4)),

            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[1], 82.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 82.0f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[1], 83.5f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[1], 83.5f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 83.5f, transform.GetChild(4)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(0)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(1)),
            new SpawnInfo(zombiePrefabArray[1], 85.0f, transform.GetChild(2)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(3)),
            new SpawnInfo(zombiePrefabArray[0], 85.0f, transform.GetChild(4))

        };

        if (level == 0)
            foreach (SpawnInfo spawnInfo in Tutorial)
                StartCoroutine(SpawnZombie(spawnInfo));
        if (level == 1)
            foreach(SpawnInfo spawnInfo in Level1)
                StartCoroutine(SpawnZombie(spawnInfo));
        if (level == 2)
            foreach (SpawnInfo spawnInfo in Level2)
                StartCoroutine(SpawnZombie(spawnInfo));
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnZombie(SpawnInfo spawnInfo)
    {
        yield return new WaitForSeconds(spawnInfo.spawnTime);
        Instantiate(spawnInfo.ZombiePrefab, spawnInfo.parent);
    }





}
