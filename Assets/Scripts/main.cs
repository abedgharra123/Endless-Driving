using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class main : MonoBehaviour
{
    [SerializeField] private TMP_Text MenuHighScore;

    
    private string highScore = "HighScore";

    private void Start() {
        MenuHighScore.text = $"Highest Score: {PlayerPrefs.GetInt(highScore,0)}";
    }
    public void Play()
    {
        SceneManager.LoadScene(1);
    }




    


}
