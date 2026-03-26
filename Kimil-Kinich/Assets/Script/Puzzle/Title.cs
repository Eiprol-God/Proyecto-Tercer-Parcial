using UnityEngine;

public class Tile : MonoBehaviour
{
    public Vector2Int posicion;
    public PuzzleManager manager;

    public void OnClick()
    {
        manager.IntentarMover(this);
    }

    public void ActualizarPosicion()
    {
        transform.localPosition = new Vector3(
            posicion.x * 100,
            posicion.y * -100,
            0
        );
    }
}