using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int posicion;
    public PuzzleManager manager;

    private RectTransform rt;

    public float tileSize = 100f;
    public int gridSize = 4;

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

        rt.anchoredPosition = new Vector2(
            (posicion.x * tileSize) - offset,
            (posicion.y * -tileSize) + offset
        );
    }
}