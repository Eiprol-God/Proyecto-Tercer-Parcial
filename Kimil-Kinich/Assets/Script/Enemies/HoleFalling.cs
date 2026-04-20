using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HoleTrigger : MonoBehaviour
{
    public EnemySpawner spawner;

    [Header("Sonido")]
    public AudioClip fallSound;

    [Header("Tiempo antes de destruir")]
    public float destroyDelay = 2f;

    private bool alreadyTriggered = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            EnemyController enemyScript = other.GetComponent<EnemyController>();

            if (enemyScript != null && !enemyScript.isDead)
            {
                enemyScript.isDead = true;
                StartCoroutine(FallAndDestroy(other.gameObject));
            }
        }
    }

    IEnumerator FallAndDestroy(GameObject enemy)
    {
        NavMeshAgent agent = enemy.GetComponent<NavMeshAgent>();
        Rigidbody rb = enemy.GetComponent<Rigidbody>();

        // Apagar navegación
        if (agent != null)
            agent.enabled = false;

        // Activar físicas
        if (rb != null)
            rb.isKinematic = false;

        // 🔊 Reproducir sonido como AudioClip
        if (fallSound != null)
            AudioSource.PlayClipAtPoint(fallSound, enemy.transform.position);

        yield return new WaitForSeconds(destroyDelay);

        if (spawner != null)
        {
            Debug.Log("Enemy murió");
            spawner.EnemyDied();
        }

        Destroy(enemy);
        alreadyTriggered = false;
    }
}