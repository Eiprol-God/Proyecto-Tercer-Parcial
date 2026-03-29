using System.Collections.Generic;
using UnityEngine;

public class CandadoManager : MonoBehaviour
{
    public List<RuedaCandado> ruedas;

    public void VerificarCodigo()
    {
        foreach (var rueda in ruedas)
        {
            if (rueda.valorActual != rueda.valorCorrecto)
            {
                Debug.Log("Código incorrecto ❌");
                return;
            }
        }

        Debug.Log("Candado abierto 🔓");
    }
}