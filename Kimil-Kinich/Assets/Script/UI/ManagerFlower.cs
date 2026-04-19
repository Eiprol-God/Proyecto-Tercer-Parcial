using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FlowerManager : MonoBehaviour
{
    public static FlowerManager instancia;

    public int flowers = 0;
    public int tflowers = 10;

    public GameObject iUI;
    public TextMeshProUGUI textoPzs;

    [Header("Spawn")]

    public GameObject prefabPieza;
    public List<Transform> puntosSpawn;

    void Awake()
    {
        instancia = this;

        iUI.SetActive(false);
        ActualizarUI();

        GenerarSiguientePieza();
    }

    public void RecogerPieza()
    {
        flowers++;

        if (flowers > 0 && !iUI.activeSelf)
            iUI.SetActive(true);

        ActualizarUI();

        if (flowers < tflowers)
        {
            GenerarSiguientePieza();
        }
    }

    void GenerarSiguientePieza()
    {
        int index = flowers; // usa el progreso como índice

        if (index < puntosSpawn.Count)
        {
            Instantiate(prefabPieza, puntosSpawn[index].position, Quaternion.identity);
        }
    }

    public void ActualizarUI()
    {
        textoPzs.text = flowers + "/" + tflowers;
    }

    public bool TieneTodas()
    {
        return flowers >= tflowers;
    }
}
