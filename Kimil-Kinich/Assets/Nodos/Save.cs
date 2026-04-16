using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements.Experimental;


public class Save : MonoBehaviour
{

     public int banco;
    [SerializeField] TextMeshProUGUI Bank;


    void OnEnable()
    {
        banco = PlayerPrefs.GetInt("Banko");
        
    }

    public void Update()
    {
        banco = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
        

        Bank.text = "Money:" + banco.ToString();

        

    }
    

    public void SaveScore()
    {
        Debug.Log(banco);
        PlayerPrefs.SetInt("Banko", banco);
        PlayerPrefs.Save();
    }

    public void LoadScore()
    {
        
        banco = PlayerPrefs.GetInt("Banko");
    }
}
