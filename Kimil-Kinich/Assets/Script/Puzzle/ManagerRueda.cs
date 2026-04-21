using System.Collections.Generic;
using UnityEngine;

public class CandadoManager : MonoBehaviour
{
    public List<RuedaCandado> ruedas;

    public GameObject MNGRueda;
    public GameObject Puerta;

    public void VerificarCodigo()
    {
        foreach (var rueda in ruedas)
        {
            if (rueda.valorActual != rueda.valorCorrecto)
            {
                return;
            }
        }

        MNGRueda.SetActive(false);
        AudioManager.instancia.ReproducirPuzzleResuelto();

        Puerta.SetActive(false);
    }
}