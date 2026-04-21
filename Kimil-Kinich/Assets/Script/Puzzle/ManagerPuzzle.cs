using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();
    public Vector2Int posicionVacia;

    public AudioSource audioSource;
    public AudioClip sonidoMover;

    public GameObject SlidePuzzle;

    public GameObject camaraPlayer;
    public GameObject camaraPuzzle;

    void Start()
    {
        foreach (Tile tile in tiles)
        {
            tile.manager = this;
            tile.posicionInicial = tile.posicion;
            tile.SetPosicionInstantanea();
        }

        Mezclar();
    }

    public void IntentarMover(Tile tile)
    {
        int distancia = Mathf.Abs(tile.posicion.x - posicionVacia.x) +
                        Mathf.Abs(tile.posicion.y - posicionVacia.y);

        if (distancia == 1)
        {
            Vector2Int temp = tile.posicion;
            tile.posicion = posicionVacia;
            posicionVacia = temp;

            tile.ActualizarPosicion();

            if (audioSource != null && sonidoMover != null)
                audioSource.PlayOneShot(sonidoMover);

            if (EstaResuelto())
            {
                SlidePuzzle.SetActive(false);

                if (camaraPuzzle != null)
                    camaraPuzzle.SetActive(false);

                if (camaraPlayer != null)
                    camaraPlayer.SetActive(true);

                AudioManager.instancia.ReproducirPuzzleResuelto();

            }
        }
    }

    void Mezclar()
    {
        for (int i = 0; i < 50; i++)
        {
            List<Tile> vecinos = ObtenerVecinos();

            if (vecinos.Count == 0) continue;

            Tile random = vecinos[Random.Range(0, vecinos.Count)];

            // Movimiento SIN animación
            Vector2Int temp = random.posicion;
            random.posicion = posicionVacia;
            posicionVacia = temp;
        }

        foreach (Tile tile in tiles)
        {
            tile.SetPosicionInstantanea();
        }
    }

    bool EstaResuelto()
    {
        foreach (Tile tile in tiles)
        {
            if (tile.posicion != tile.posicionInicial)
                return false;
        }

        return true;
    }

    List<Tile> ObtenerVecinos()
    {
        List<Tile> vecinos = new List<Tile>();

        foreach (Tile tile in tiles)
        {
            int distancia = Mathf.Abs(tile.posicion.x - posicionVacia.x) +
                            Mathf.Abs(tile.posicion.y - posicionVacia.y);

            if (distancia == 1)
                vecinos.Add(tile);
        }

        return vecinos;
    }

    public void Reiniciar()
    {
        foreach (Tile tile in tiles)
        {
            tile.posicion = tile.posicionInicial;
        }

        posicionVacia = new Vector2Int(3, 3);

        Mezclar();
    }
}