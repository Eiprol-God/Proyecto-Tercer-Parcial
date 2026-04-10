using System.Collections.Generic;
using UnityEngine;

public class CriptaManager : MonoBehaviour
{
    public List<int> ordenCorrecto = new List<int> { 2, 0, 3, 1 };

    private int progreso = 0;

    public void PresionarCripta(Cripta cripta)
    {
        if (cripta.id == ordenCorrecto[progreso])
        {
            Debug.Log("Correcto 👍");

            progreso++;

            if (progreso >= ordenCorrecto.Count)
            {
                Debug.Log("Puzzle completado 🎉");
                AudioManager.instancia.ReproducirPuzzleResuelto();
                // Aquí puedes abrir puerta o lo que quieras
            }
        }
        else
        {
            Debug.Log("Incorrecto ❌");
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
