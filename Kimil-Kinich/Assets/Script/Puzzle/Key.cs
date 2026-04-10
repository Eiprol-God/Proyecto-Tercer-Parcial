using UnityEngine;

public class Key : MonoBehaviour
{
    public AudioClip sonido;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonido, transform.position);

            KeyManager.instancia.ObtenerLlave();

            Destroy(gameObject);
        }
    }
}
