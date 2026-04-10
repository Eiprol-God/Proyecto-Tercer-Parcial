using UnityEngine;

public class AltarPuzzle : MonoBehaviour
{
    public GameObject objetoFoto;
    public GameObject objetoFlores;

    public GameObject puerta;

    private bool fotoColocada = false;
    private bool floresColocadas = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        // Colocar foto
        if (!fotoColocada && PhotoManager.instancia.TieneTodas())
        {
            objetoFoto.SetActive(true);
            fotoColocada = true;
            Debug.Log("Foto colocada 🖼️");
        }

        // Colocar flores
        if (!floresColocadas && FlowerManager.instancia.TieneTodas())
        {
            objetoFlores.SetActive(true);
            floresColocadas = true;
            Debug.Log("Flores colocadas 🌸");
        }

        VerificarPuzzle();
    }

    void VerificarPuzzle()
    {
        if (fotoColocada && floresColocadas)
        {
            Debug.Log("Puzzle completo 🎉");

            if (puerta != null)
                puerta.SetActive(false); // o animación después

            AudioManager.instancia.ReproducirPuzzleResuelto();
        }
    }
}
