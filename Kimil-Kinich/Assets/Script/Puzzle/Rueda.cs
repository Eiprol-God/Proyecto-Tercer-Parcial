using UnityEngine;

public class RuedaCandado : MonoBehaviour
{
    public int valorActual = 0;
    public int valorCorrecto = 0;

    public AudioClip sonidoClick;

    public float gradosPorPaso = 40f;

    bool girando = false;
    Quaternion rotacionObjetivo;
    float velocidad = 10f;

    void Update()
    {
        if (girando)
        {
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotacionObjetivo, Time.deltaTime * velocidad);

            if (Quaternion.Angle(transform.localRotation, rotacionObjetivo) < 0.5f)
            {
                transform.localRotation = rotacionObjetivo;
                girando = false;
            }
        }
    }

    public void Girar()
    {
        if (girando) return; // evita spam

        valorActual = (valorActual + 1) % 10;

        float angulo = -valorActual * gradosPorPaso;
        rotacionObjetivo = Quaternion.Euler(angulo, 0, 0);

        girando = true;
    }

    void OnMouseDown()
    {
        Girar();
        AudioSource.PlayClipAtPoint(sonidoClick, transform.position);
    }
}