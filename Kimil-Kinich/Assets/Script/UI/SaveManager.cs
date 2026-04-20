using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instancia;

    void Awake()
    {
        instancia = this;
    }

    // 🔹 GUARDAR
    public void Guardar()
    {
        // Llave
        PlayerPrefs.SetInt("tieneLlave", KeyManager.instancia.tieneLlave ? 1 : 0);

        // Fotos
        PlayerPrefs.SetInt("piezas", PhotoManager.instancia.piezas);

        // Flores
        PlayerPrefs.SetInt("flowers", FlowerManager.instancia.flowers);

        PlayerPrefs.Save();

        Debug.Log("Partida guardada 💾");
    }

    public void Cargar()
	{
    	KeyManager.instancia.tieneLlave = PlayerPrefs.GetInt("tieneLlave", 0) == 1;

    	PhotoManager.instancia.piezas = PlayerPrefs.GetInt("piezas", 0);
    	FlowerManager.instancia.flowers = PlayerPrefs.GetInt("flowers", 0);

    	// 🔥 ACTUALIZAR UI
    	PhotoManager.instancia.ActualizarUI();
    	FlowerManager.instancia.ActualizarUI();

    	Debug.Log("Partida cargada 📂");
	}

	public void BorrarDatos()
	{
    	PlayerPrefs.DeleteAll();
    	PlayerPrefs.Save();

    	// 🔁 Resetear datos en memoria
    	if (KeyManager.instancia != null)
        	KeyManager.instancia.tieneLlave = false;

    	if (PhotoManager.instancia != null)
    	{
        	PhotoManager.instancia.piezas = 0;
        	PhotoManager.instancia.ActualizarUI();
        	PhotoManager.instancia.inventoryUI.SetActive(false);
    	}

    	if (FlowerManager.instancia != null)
    	{
        	FlowerManager.instancia.flowers = 0;
        	FlowerManager.instancia.ActualizarUI();
        	FlowerManager.instancia.iUI.SetActive(false);
    	}

    	Debug.Log("Datos borrados 🧹");
	}

}
