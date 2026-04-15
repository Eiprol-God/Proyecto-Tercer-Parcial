using System.Collections;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {

        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f,5), Random.Range(-6f,6f),0),Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
