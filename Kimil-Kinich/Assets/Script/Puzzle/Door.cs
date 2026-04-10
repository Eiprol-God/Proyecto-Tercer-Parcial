using UnityEngine;

public class Door : MonoBehaviour
{
    public bool requiereLlave = true;

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
        }
    }

    void AbrirPuerta()
    {
        Debug.Log("Puerta abierta 🚪");

        // Opción simple:
        gameObject.SetActive(false);

        // luego podemos meter animación 👀
    }
}
