using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main : MonoBehaviour
{
    [SerializeField] private TMP_Text MenuHighScore;
    [SerializeField] private TMP_Text PlayText;
    [SerializeField] private int MaxEnergy;
    [SerializeField] private int TimeToRecharge;
    [SerializeField] private AndroidNotificationHandler ANH;
    private int Energy;
    
    private string highScore = "HighScore";
    private void Start() {
        MenuHighScore.text = $"Highest Score: {PlayerPrefs.GetInt(highScore,0)}";
        Energy = PlayerPrefs.GetInt("Energy",MaxEnergy);
        if (Energy == 0){
            string TimeToRechargeString = PlayerPrefs.GetString("TimeToRecharge",string.Empty);
            if (TimeToRechargeString == string.Empty) {return;}
            DateTime RechargeTime = DateTime.Parse(TimeToRechargeString);
            if(DateTime.Now > RechargeTime){
                Energy = MaxEnergy;
                PlayerPrefs.SetInt("Energy",Energy);
            } 

        }
        PlayText.text = $"Play({Energy})";
    }
    public void Play()
    {
        if( Energy > 0 ){
            Energy -= 1;
            if(Energy == 0){
                PlayerPrefs.SetString("TimeToRecharge",DateTime.Now.AddSeconds(TimeToRecharge).ToString());
                #if UNITY_ANDROID
                ANH.ScheduleNotification(DateTime.Now.AddSeconds(TimeToRecharge));
                #endif

            }
            PlayerPrefs.SetInt("Energy",Energy);
            SceneManager.LoadScene(1);
        }
        
    }
    


}
