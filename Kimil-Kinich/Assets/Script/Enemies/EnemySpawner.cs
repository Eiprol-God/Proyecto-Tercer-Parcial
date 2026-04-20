using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn")]
    public GameObject enemyPrefab;
    public Transform spawnPoint;

    [Header("Control")]
    public bool playerHasKey = false;

    private GameObject currentEnemy;

    void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        if (!playerHasKey && currentEnemy == null)
        {
            currentEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }

    public void EnemyDied()
    {
        currentEnemy = null;

        if (!playerHasKey)
        {
            SpawnEnemy();
        }
    }
}