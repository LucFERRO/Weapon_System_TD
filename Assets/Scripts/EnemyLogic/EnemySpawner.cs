using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private Vector3 spawnBounds;
    [SerializeField] private Transform enemiesContainer;
    [SerializeField] private GameObject enemyPrefab;

    private float nextSpawnTime;

    void Update()
    {
        if(Time.time > nextSpawnTime)
        {
            SetNextSpawnTime();
            SpawnEnemy();
        }
    }

    private void SpawnEnemy()
    {
        Vector3 rdPos = Random.insideUnitCircle;
        rdPos.y = 0;
        Instantiate(enemyPrefab, transform.position + rdPos, Quaternion.identity, enemiesContainer);
    }

    private void SetNextSpawnTime()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, spawnBounds);
    }
}
