using System.Collections.Generic;
using UnityEngine;

public class CriptaManager : MonoBehaviour
{
    public List<int> ordenCorrecto = new List<int> { 2, 0, 3, 1 };
    public GameObject Puertita;

    private int progreso = 0;

    public void PresionarCripta(Cripta cripta)
    {
        if (cripta.id == ordenCorrecto[progreso])
        {

            progreso++;

            if (progreso >= ordenCorrecto.Count)
            {
                Puertita.SetActive(false);
                AudioManager.instancia.ReproducirPuzzleResuelto();
            }
        }
        else
        {
            Reiniciar();
        }
    }

    void Reiniciar()
	{
    	progreso = 0;

    	foreach (Cripta c in FindObjectsOfType<Cripta>())
    	{
        	c.Resetear();
    	}
	}
}
