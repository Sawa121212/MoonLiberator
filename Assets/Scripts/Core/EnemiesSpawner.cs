using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemiesSpawner : MonoBehaviour
{
    /// <summary>
    /// Список созданных врагов
    /// </summary>
    public List<Enemy> SpawnedEnemies = new();


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (HasWaves && Time.timeSinceLevelLoad > CurrentWave.SpawnTime)
        {
            Spawn();
        }
    }

    private void Spawn()
    {
        int count = UnityEngine.Random.Range(CurrentWave.countMin, CurrentWave.countMax + 1);
        for (int i = 0; i < count; i++)
        {
            var position = center.position + (Vector3)UnityEngine.Random.insideUnitCircle * spawnRadius;
            var item = Instantiate(CurrentWave.EnemyPrefab, position, Quaternion.identity);
            item.EnemiesSpawnerModel = this;
            SpawnedEnemies.Add(item);
        }

        waveIndex++;
    }

    public void OnEnemyDead(Enemy enemy)
    {
        if (enemy == null || !SpawnedEnemies.Contains(enemy))
        {
            return;
        }

        SpawnedEnemies.Remove(enemy);
        Debug.Log(enemy.name + " is removed");
    }


    [SerializeField] private Wave[] waves;
    [SerializeField] private float spawnRadius;
    [SerializeField] private Transform center;
    private Wave CurrentWave => waves[waveIndex];
    private bool HasWaves => waveIndex < waves.Length;
    private int waveIndex;

    /// <summary>
    /// Волна
    /// </summary>
    [Serializable]
    public class Wave
    {
        public float SpawnTime;
        public Enemy EnemyPrefab;
        public int countMin, countMax;
    }
}