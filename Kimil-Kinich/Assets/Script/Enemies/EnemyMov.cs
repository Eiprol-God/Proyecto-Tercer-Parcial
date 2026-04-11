using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Referencias")]
    public Transform player;

    [Header("Movimiento")]
    public float detectionRange = 10f;
    private NavMeshAgent agent;

    [Header("Daño")]
    public int damage = 1;
    public float damageCooldown = 1.5f;
    private float lastDamageTime;

    [HideInInspector]
	public bool isDead = false;

    void Start()
	{
    	agent = GetComponent<NavMeshAgent>();

    	if (player == null)
    	{
        	player = GameObject.FindGameObjectWithTag("Player").transform;
    	}
	}

    void Update()
	{
    	if (player == null || agent == null || !agent.enabled)
        	return;

    	float distance = Vector3.Distance(transform.position, player.position);

    	if (distance <= detectionRange)
    	{
        	agent.SetDestination(player.position);
    	}
    	else
    	{
        	agent.ResetPath();
    	}
	}

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Time.time >= lastDamageTime + damageCooldown)
            {
                // Llama al script del jugador (cuando lo tengas)
                collision.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);

                lastDamageTime = Time.time;
            }
        }
    }
}