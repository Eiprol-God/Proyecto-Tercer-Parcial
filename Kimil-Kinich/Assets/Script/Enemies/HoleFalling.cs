using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class HoleTrigger : MonoBehaviour
{
	public EnemySpawner spawner;
	
    [Header("Sonido")]
    public AudioSource fallSound;

    [Header("Tiempo antes de destruir")]
    public float destroyDelay = 2f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(FallAndDestroy(other.gameObject));
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

        // Reproducir sonido
        if (fallSound != null)
            fallSound.Play();

        yield return new WaitForSeconds(destroyDelay);

        Destroy(enemy);
    }
}