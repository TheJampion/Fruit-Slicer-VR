using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private List<Spawner> spawns = new List<Spawner>();
    [SerializeField] private float spawnInterval = 3.5f;
    [SerializeField] private float spawnDelay = 0.15f;
    private float timer;

    private void SpawnNewObjects()
    {
        StartCoroutine(SpawnObjectOnTimer());
    }

    private IEnumerator SpawnObjectOnTimer()
    {
        int numberToSpawn = UnityEngine.Random.Range(1, spawns.Count);
        WaitForSeconds delay = new WaitForSeconds(spawnDelay);
        List<int> spawnedIndexes = new List<int>();
        var random = new System.Random();

        for (int i=0; i < spawns.Count; i++)
        {
            spawnedIndexes.Add(i);
        }

        for(int i=0; i < numberToSpawn; i++)
        {
            int index = random.Next(spawnedIndexes.Count);
            spawns[index].SpawnNewObject();
            spawnedIndexes.RemoveAt(index);
            yield return delay;
        }
    }

    void Update()
    {
        if (!GameManager.instance.isStarted) return;
        timer += Time.deltaTime;
        if(timer >= spawnInterval)
        {
            timer = 0;
            SpawnNewObjects();
        }
    }
}
