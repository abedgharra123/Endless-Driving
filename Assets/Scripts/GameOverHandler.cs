
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject scoreSystemObject;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 position;
    [SerializeField] private Quaternion look;
    [SerializeField] private Button continueButton;
    [SerializeField] GameObject gameOverHandlerDisplay; 
    public void ContinueGame(){
        ScoreSystem s = scoreSystemObject.GetComponent<ScoreSystem>();
        gameOverHandlerDisplay.SetActive(false);
        player.transform.position = position;
        player.transform.rotation = look;
        player.SetActive(true);
        s.ContinueGame();
    }

    public void ContinueButton(){
        AdManager.instance.ShowAd(this);
        continueButton.interactable = false;
        
    }

    public void MenuButton(){
        SceneManager.LoadScene(0);
    }

    public void PlayagainButton(){
        SceneManager.LoadScene(1);
    }
}
