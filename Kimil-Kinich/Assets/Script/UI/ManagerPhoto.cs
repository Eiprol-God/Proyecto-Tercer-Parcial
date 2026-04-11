using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public static PhotoManager instancia;

    public int piezas = 0;
    public int total = 5;

    public GameObject inventoryUI;
    public TextMeshProUGUI textoPiezas;

    [Header("Spawn")]
    
    public GameObject prefabPieza;
    public List<Transform> puntosSpawn;

    void Awake()
    {
        instancia = this;

        inventoryUI.SetActive(false);
        ActualizarUI();

        GenerarSiguientePieza();
    }

    public void RecogerPieza()
    {
        piezas++;

        if (piezas > 0 && !inventoryUI.activeSelf)
            inventoryUI.SetActive(true);

        ActualizarUI();

        if (piezas < total)
        {
            GenerarSiguientePieza();
        }
    }

    void GenerarSiguientePieza()
    {
        int index = piezas; // usa el progreso como índice

        if (index < puntosSpawn.Count)
        {
            Instantiate(prefabPieza, puntosSpawn[index].position, Quaternion.identity);
        }
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
