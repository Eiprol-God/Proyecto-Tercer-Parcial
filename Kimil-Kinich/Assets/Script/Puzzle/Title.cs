using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int posicion;
    public PuzzleManager manager;

    public Vector2Int posicionInicial;

    private RectTransform rt;

    public float tileSize = 200f;
    public int gridSize = 8;

    bool moviendo = false;
    Vector2 targetPos;
    float velocidad = 10f;

    void Awake()
    {
        rt = GetComponent<RectTransform>();
    }

    public void OnClick()
    {
        if (manager != null)
        {
            manager.IntentarMover(this);
        }
        else
        {
            Debug.LogWarning("Manager no asignado en " + gameObject.name);
        }
    }

    public void ActualizarPosicion()
    {
        float offset = (gridSize - 1) / 2f * tileSize;

        targetPos = new Vector2(
            (posicion.x * tileSize) - offset,
            (posicion.y * -tileSize) + offset
            );

        moviendo = true;
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