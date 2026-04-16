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
    int newbank;
    public int banco;
    [SerializeField] TextMeshProUGUI Bank;


    

    public void Update()
    {

        // banco = banco + Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
        Bank.text = "Money:" + banco.ToString();


    }


    public void SaveScore()
    {

           
            banco = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
            Debug.Log(banco);
            PlayerPrefs.SetInt("Banko", banco);
            PlayerPrefs.Save();
        } 

    public void LoadScore()
    {
        
        banco = PlayerPrefs.GetInt("Banko");
        Variables.Scene(SceneManager.GetActiveScene()).Set("Money", banco);
        Debug.Log(banco);
    }

    public void DeleteData()
    {
        PlayerPrefs.DeleteKey("Input");
        PlayerPrefs.DeleteAll();
    }
}
