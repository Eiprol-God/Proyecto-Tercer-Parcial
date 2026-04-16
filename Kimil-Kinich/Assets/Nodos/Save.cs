using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;
using static UnityEngine.Rendering.DebugUI;


public class Save : MonoBehaviour
{
    public int banco;
    public float salud;
    public int contador;
    public int vida;
    [SerializeField] TextMeshProUGUI Bank;
    [SerializeField] TextMeshProUGUI Health;
    [SerializeField] TextMeshProUGUI Enemy_Death;
    [SerializeField] TextMeshProUGUI Lives;


    public void Update()
    {

        // banco = banco + Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
        Bank.text = "Money:" + banco.ToString();
        Health.text = "Health:" + salud.ToString();
        Enemy_Death.text = "Enemies Killed:" + contador.ToString();
        Lives.text = "Lives:" + vida.ToString();
    }


    public void SaveScore()
    {

           
            banco = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
            Debug.Log(banco);
            PlayerPrefs.SetInt("Banko", banco);
            
            salud = Variables.Scene(SceneManager.GetActiveScene()).Get<float>("Health_Player");
            Debug.Log(salud);
            PlayerPrefs.SetFloat("Salud",salud);

            contador = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Counter");
            Debug.Log(contador);
            PlayerPrefs.SetInt("Contador",contador);

            vida = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Health_Player");
            Debug.Log(vida);
            PlayerPrefs.SetInt("Vida", vida);



        PlayerPrefs.Save();
        } 

    public void LoadScore()
    {
        
        banco = PlayerPrefs.GetInt("Banko");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Money", banco);
        Debug.Log(banco);

        salud = PlayerPrefs.GetFloat("Salud");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Health_Player", salud);
        Debug.Log(salud);

        contador = PlayerPrefs.GetInt("Contador");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Counter", contador);
        Debug.Log(contador);

        vida = PlayerPrefs.GetInt("Vida");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Health_Player", vida);
        Debug.Log(vida);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Input");
        PlayerPrefs.DeleteAll();
    }
}
