using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instancia;

    public AudioClip sonidoPuzzleResuelto;

    private void Awake()
    {
        instancia = this;
    }

    public void ReproducirPuzzleResuelto()
    {
        AudioSource.PlayClipAtPoint(sonidoPuzzleResuelto, Camera.main.transform.position);
    }
}
