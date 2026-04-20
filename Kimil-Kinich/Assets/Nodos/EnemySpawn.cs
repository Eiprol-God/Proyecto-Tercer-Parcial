using System.Collections;
using UnityEngine;

public class EnemySpawn2 : MonoBehaviour
{
    [SerializeField]
    private GameObject swarmerPrefab;
    [SerializeField]
    private GameObject bigSwarmerPrefab;
    [SerializeField]
    private GameObject smallSwarmerPrefab;

    [SerializeField]
    private float swarmerInterval = 3.5f;
    [SerializeField]
    private float bigSwarmerInterval = 10f;
    [SerializeField]
    private float smallSwarmerInterval = 10f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(spawnEnemy(swarmerInterval, swarmerPrefab));
        StartCoroutine(spawnEnemy(bigSwarmerInterval, bigSwarmerPrefab));
        StartCoroutine(spawnEnemy(smallSwarmerInterval, smallSwarmerPrefab));
    }

    
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {

        yield return new WaitForSeconds(interval);
        GameObject newEnemy = Instantiate(enemy, new Vector3(28,0, 94f), Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
