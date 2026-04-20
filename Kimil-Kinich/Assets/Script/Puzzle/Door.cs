using UnityEngine;

public class Door : MonoBehaviour
{
    public bool requiereLlave = true;
    public AudioClip sonidoopen;
    public AudioClip sonidoclosed;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        if (!requiereLlave || KeyManager.instancia.tieneLlave)
        {
            AbrirPuerta();
        }
        else
        {
            Debug.Log("Necesitas una llave ❌");
            AudioSource.PlayClipAtPoint(sonidoclosed, transform.position);
        }
    }

    void AbrirPuerta()
    {
        Debug.Log("Puerta abierta 🚪");

        // Opción simple:
        gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(sonidoopen, transform.position);

        // luego podemos meter animación 👀
    }
}
