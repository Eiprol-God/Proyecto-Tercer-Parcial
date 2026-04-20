using UnityEngine;

public class FlowerPickup : MonoBehaviour
{
    public AudioClip sonidoRecoger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            AudioSource.PlayClipAtPoint(sonidoRecoger, transform.position);

            FlowerManager.instancia.RecogerPieza();

            Destroy(gameObject);
        }
    }
}