using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class UI_Elements_Screen : MonoBehaviour
{

    public int banco;
    public int contador;

    [SerializeField] TextMeshProUGUI Bank;

    [SerializeField] TextMeshProUGUI Enemy_Death;
 


    public void Update()
    {

        // banco = banco + Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
        Bank.text = "Money:" + banco.ToString();
       
        Enemy_Death.text = "Enemies Killed:" + contador.ToString();
        
    }
     void values()
    {
        banco = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
        contador = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Counter");
    }
    public void LoadScore()
    {

        banco = PlayerPrefs.GetInt("Banko");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Money", banco);
        
       

        contador = PlayerPrefs.GetInt("Contador");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Counter", contador);
       

        
    }
}