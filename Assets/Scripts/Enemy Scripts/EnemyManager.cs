using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    public GameObject enemyType;
    public Transform[] spawnPoints;
}

[System.Serializable]
public class Wave
{
    public List<EnemySpawnData> enemySpawnDataList = new List<EnemySpawnData>();
    public float timeBetweenSpawns = 1f; // Time between spawning each enemy
}

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [Header("Enemy Data")]
    public List<Wave> waves = new List<Wave>();
    public int maxEnemies = 100; // Maximum number of enemies allowed
    public float spawnInterval = 180f; // Time in seconds to spawn enemies

    [Header("Object Pooling")]
    public int poolSize = 20; // Default pool size
    private List<GameObject> enemyPool = new List<GameObject>();

    private int currentWaveIndex = 0;

    private void Awake()
    {
        Singleton();
        InitializeObjectPool();
    }

    void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemiesIndefinitely());
    }

    private void InitializeObjectPool()
    {
        foreach (Wave wave in waves)
        {
            foreach (EnemySpawnData data in wave.enemySpawnDataList)
            {
                for (int i = 0; i < poolSize; i++)
                {
                    GameObject enemy = Instantiate(data.enemyType);
                    enemy.SetActive(false);
                    enemyPool.Add(enemy);
                }
            }
        }
    }

    private GameObject GetPooledEnemy(GameObject enemyType)
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (!enemy.activeInHierarchy && enemy.name.Contains(enemyType.name))
            {
                return enemy;
            }
        }
        return null; // No available object in the pool
    }

    private IEnumerator SpawnEnemiesIndefinitely()
    {
        while (true)
        {
            int enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

            if (enemyCount < maxEnemies)
            {
                StartWave(currentWaveIndex);
                currentWaveIndex = (currentWaveIndex + 1) % waves.Count; // Loop back to the first wave after the last wave
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void StartWave(int waveIndex)
    {
        if (waveIndex < waves.Count)
        {
            StartCoroutine(SpawnWave(waves[waveIndex]));
        }
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        foreach (EnemySpawnData spawnData in wave.enemySpawnDataList)
        {
            Transform randomSpawnPoint = spawnData.spawnPoints[Random.Range(0, spawnData.spawnPoints.Length)];
            GameObject enemyToSpawn = GetPooledEnemy(spawnData.enemyType);
            if (enemyToSpawn != null)
            {
                enemyToSpawn.transform.position = randomSpawnPoint.position;
                enemyToSpawn.transform.rotation = randomSpawnPoint.rotation;
                enemyToSpawn.SetActive(true);
            }
            yield return new WaitForSeconds(wave.timeBetweenSpawns);
        }
    }
}