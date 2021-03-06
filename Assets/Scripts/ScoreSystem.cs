using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreText;
    private const string highScore = "HighScore";

    
    private bool count = true;
    private float score;
    // Update is called once per frame
    void Update()
    {
        if (!count) return;
        score += Time.deltaTime*2;
        scoreText.text = ((int)score).ToString();
    }
    private void OnDestroy() {
        int OldScore = PlayerPrefs.GetInt(highScore,0);
        if (score > OldScore){
            PlayerPrefs.SetInt(highScore,(int)score);
        }
        
    }
    public void ContinueGame(){
        count = true;
    }
    public int EndGame(){
        count = false;
        int OldScore = PlayerPrefs.GetInt(highScore,0);
        if (score > OldScore){
            PlayerPrefs.SetInt(highScore,(int)score);
        }
        return (int)score;
    }

    public int GetScore(){return (int)score;}
}
