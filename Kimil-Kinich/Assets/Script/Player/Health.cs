using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    [Header("Vida")]
    public int maxHealth = 3;
    private int currentHealth;

    [Header("Invulnerabilidad")]
    public float invulnerabilityTime = 1f;
    private bool isInvulnerable = false;

    [Header("Sonido")]
    public AudioClip deathSound;

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

    public void Die()
    {
        StartCoroutine(Morir());
    }

    IEnumerator Morir()
    {
        Debug.Log("El jugador murió 💀");

        // 🔊 reproducir sonido
        if (deathSound != null)
            AudioSource.PlayClipAtPoint(deathSound, transform.position);

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("GameOver");
    }
}