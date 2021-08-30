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
    [SerializeField] private TMP_Text PlayText;
    [SerializeField] private int MaxEnergy;
    [SerializeField] private int TimeToRecharge;
    [SerializeField] private AndroidNotificationHandler ANH;
    [SerializeField] private TMP_Text timeToRechargeText;
    [SerializeField] private Button adButton;
    private int Energy;
    
    private string highScore = "HighScore";

     private void Start() {
        OnApplicationFocus(true);
    }
    private void OnApplicationFocus(bool focusStatus) 
    {
        if (!focusStatus) return;
        CancelInvoke();
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
            else{
                Invoke(nameof(RechargeEnergy),(float)(RechargeTime - DateTime.Now).TotalSeconds);
                
            }

        }
        PlayText.text = $"Play({Energy})";
    }

    private void RechargeEnergy(){
        Energy = MaxEnergy;
        PlayerPrefs.SetInt("Energy",Energy);
        PlayText.text = $"Play({Energy})";
    }
    void Update(){
        if (Energy > 0) return;
        string TimeToRechargeString = PlayerPrefs.GetString("TimeToRecharge",string.Empty);
        DateTime RechargeTime = DateTime.Parse(TimeToRechargeString);
        int secondsToRecharge = (int)(RechargeTime - DateTime.Now).TotalSeconds;
        if (secondsToRecharge <= 60){
            timeToRechargeText.text = $"{secondsToRecharge}s to Recharge";
            if(secondsToRecharge <= 0.5) timeToRechargeText.text = "";
        } else {
            int minutes = secondsToRecharge / 60;
            int seconds = secondsToRecharge % 60;
            timeToRechargeText.text = $"{minutes}m {seconds}s to Recharge";
        }
        
    }

    public void Play()
    {
        if( Energy > 0 ){
            Energy -= 1;
            if(Energy == 0){
                PlayerPrefs.SetString("TimeToRecharge",DateTime.Now.AddMinutes(TimeToRecharge).ToString());
                #if UNITY_ANDROID
                ANH.ScheduleNotification(DateTime.Now.AddMinutes(TimeToRecharge));
                #endif

            }
            PlayerPrefs.SetInt("Energy",Energy);
            SceneManager.LoadScene(1);
        }
        
        
    }
    


}
