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

    public int banko = (0);
    [SerializeField] TextMeshProUGUI Bank;

   public void Awake()
    {
        
    }
    public void Update()
    {
        int banko = Variables.Scene(SceneManager.GetActiveScene()).Get<int>("Money");

        Bank.text = "Money:" + banko.ToString();
        
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("Money:", banko );
    }

    public void LoadScore()
    {
        banko = PlayerPrefs.GetInt("Money:");
    }
}
