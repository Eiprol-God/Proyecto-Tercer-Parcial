using System.Collections;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Invulnerabilidad")]
    public float invulnerabilityTime = 1f;
    private bool isInvulnerable = false;

    public HeartsUI heartsUI;

    void Start()
	{
    	currentHealth = maxHealth;
    	heartsUI.UpdateHearts(currentHealth);
	}

    public void TakeDamage(int damage)
    {
        if (isInvulnerable) return;

        currentHealth -= damage;

		heartsUI.UpdateHearts(currentHealth);

        Debug.Log("Vida actual: " + currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
        else
        {
            StartCoroutine(Invulnerability());
        }
    }

    IEnumerator Invulnerability()
    {
        isInvulnerable = true;

        yield return new WaitForSeconds(invulnerabilityTime);

        isInvulnerable = false;
    }

    void Die()
    {
        Debug.Log("El jugador murió");

        // Aquí luego conectamos:
        // - UI
        // - Timer
        // - Reinicio
    }
}