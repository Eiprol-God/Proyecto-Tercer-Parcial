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

   public  static int banco = 0;
    [SerializeField] TextMeshProUGUI Bank;

   
    public void Update()
    {
        int banco = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");
        

        Bank.text = "Money:" + banco.ToString();
        


    }
    

    public void SaveScore()
    {
        Debug.Log(banco);
        PlayerPrefs.SetInt("Money", banco);
    }

    public void LoadScore()
    {
        Debug.Log(banco);
        banco = PlayerPrefs.GetInt("Money");
    }
}
