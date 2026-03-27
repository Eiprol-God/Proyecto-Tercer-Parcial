using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public List<Tile> tiles = new List<Tile>();
    public Vector2Int posicionVacia;

    void Start()
    {
        // Asegurar que todas las tiles tengan referencia al manager
        foreach (Tile tile in tiles)
        {
            tile.manager = this;
            tile.ActualizarPosicion();
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
        }
    }

    void Mezclar()
    {
        for (int i = 0; i < 50; i++)
        {
            List<Tile> vecinos = ObtenerVecinos();

            if (vecinos.Count == 0) continue;

            Tile random = vecinos[Random.Range(0, vecinos.Count)];
            IntentarMover(random);
        }
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
}