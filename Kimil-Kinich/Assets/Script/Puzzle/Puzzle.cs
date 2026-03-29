using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int posicion;
    public Vector2Int posicionInicial;
    public PuzzleManager manager;

    private RectTransform rt;

    public float tileSize = 200f;
    public int gridSize = 8;

    private bool moviendo = false;
    private Vector2 targetPos;
    private float velocidad = 10f;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnClick()
    {
        if (manager != null)
            manager.IntentarMover(this);
    }

    public void ActualizarPosicion()
    {
        float offset = (gridSize - 2) / 4f * tileSize;

        targetPos = new Vector2(
            (posicion.x * tileSize) - offset,
            (posicion.y * -tileSize) + offset
        );

        moviendo = true;
    }

    public void SetPosicionInstantanea()
    {
        float offset = (gridSize - 2) / 4f * tileSize;

        Vector2 pos = new Vector2(
            (posicion.x * tileSize) - offset,
            (posicion.y * -tileSize) + offset
        );

        rt.anchoredPosition = pos;
        targetPos = pos;
        moviendo = false;
    }

    void Update()
    {
        if (moviendo)
        {
            rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, targetPos, Time.deltaTime * velocidad);

            if (Vector2.Distance(rt.anchoredPosition, targetPos) < 0.1f)
            {
                rt.anchoredPosition = targetPos;
                moviendo = false;
            }
        }
    }
}