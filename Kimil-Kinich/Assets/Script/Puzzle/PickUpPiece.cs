using UnityEngine;

public class PickUpPiece : MonoBehaviour
{
    public AudioClip sonidoRecoger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonidoRecoger, transform.position);

            PhotoManager.instancia.RecogerPieza();

            Destroy(gameObject);
        }
    }
}
