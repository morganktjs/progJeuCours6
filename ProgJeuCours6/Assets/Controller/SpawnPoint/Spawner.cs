using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1;
    private float timeLeftBeforeSpawn = 0;
    private SpawnPoint[] spawnPoints;
    public GameObject ennemiCubePrefab;
    void Start()
    {
        spawnPoints = FindObjectsOfType<SpawnPoint>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateSpawn();
    }

    private void UpdateSpawn()
    {
        timeLeftBeforeSpawn -= Time.deltaTime;
        if (timeLeftBeforeSpawn <= 0)
        {
            SpawnEnnemiCube();
            timeLeftBeforeSpawn = spawnRate;
        }
    }

    private void SpawnEnnemiCube()
    {
        int countSpawnPoint = spawnPoints.Length;
        int randomSpawnPointIndex = Random.Range(0, countSpawnPoint - 1);
        Instantiate(ennemiCubePrefab, spawnPoints[randomSpawnPointIndex].transform.position, Quaternion.identity);
    }
}
