using UnityEngine;

public class ActivarCamara : MonoBehaviour
{
    public GameObject camaraPuzzle;
    public GameObject camaraJugador;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        camaraPuzzle.SetActive(true);
        camaraJugador.SetActive(true);
    }
}
