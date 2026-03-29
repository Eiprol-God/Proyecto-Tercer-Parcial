using UnityEngine;

public class PhotoPiece : MonoBehaviour
{
    public AudioClip sonidoRecoger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Reproducir sonido en el mundo
            AudioSource.PlayClipAtPoint(sonidoRecoger, transform.position);

            PhotoManager.instancia.RecogerPieza();

            Destroy(gameObject);
        }
    }
}
