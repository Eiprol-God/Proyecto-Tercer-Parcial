using UnityEngine;

public class KeyManager : MonoBehaviour
{
    public static KeyManager instancia;

    public bool tieneLlave = false;

    void Awake()
    {
        instancia = this;
    }

    public void ObtenerLlave()
    {
        tieneLlave = true;
        Debug.Log("Llave obtenida 🔑");
    }
}
