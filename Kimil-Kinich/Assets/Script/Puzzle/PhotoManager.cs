using TMPro;
using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public static PhotoManager instancia;

    public int piezas = 0;
    public int total = 10;

    public GameObject inventoryUI;
    public TextMeshProUGUI textoPiezas;

    void Awake()
    {
        instancia = this;

        // Ocultar UI al inicio
        inventoryUI.SetActive(false);
        ActualizarUI();
    }

    public void RecogerPieza()
    {
        piezas++;

        if (piezas > 0 && !inventoryUI.activeSelf)
        {
            inventoryUI.SetActive(true);
        }

        ActualizarUI();
    }

    void ActualizarUI()
    {
        textoPiezas.text = piezas + "/" + total;
    }

    public bool TieneTodas()
    {
        return piezas >= total;
    }
}