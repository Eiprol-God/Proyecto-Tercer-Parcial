using UnityEngine;

public class Cripta : MonoBehaviour
{
    public int id;
    public CriptaManager manager;
    public AudioClip sonidoPiedra;

    private Vector3 posicionInicial;
    private Vector3 posicionPresionada;

    private bool presionada = false;
    private bool animando = false;

    public float distancia = 0.2f;
    public float velocidad = 5f;

    void Start()
    {
        posicionInicial = transform.position;
        posicionPresionada = posicionInicial + transform.forward * distancia;
    }

    void OnMouseDown()
	{
    	if (presionada) return;

        AudioSource.PlayClipAtPoint(sonidoPiedra, transform.position);

    	manager.PresionarCripta(this);
    	presionada = true;
    	animando = true;
	}

    void Update()
    {
        if (animando)
        {
            transform.position = Vector3.Lerp(transform.position, posicionPresionada, Time.deltaTime * velocidad);

            if (Vector3.Distance(transform.position, posicionPresionada) < 0.01f)
            {
                transform.position = posicionPresionada;
                animando = false;
            }
        }
    }

    public void Resetear()
    {
        presionada = false;
        transform.position = posicionInicial;
    }
}
