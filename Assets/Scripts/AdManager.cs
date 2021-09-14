
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;


public class AdManager : MonoBehaviour, IUnityAdsListener
{
    [SerializeField] private bool testMode = true;

#if UNITY_ANDROID
    private string gameId = "4287201";
#elif UNITY_IOS
    private string gameId = "4287200";
#endif
    public static AdManager instance;

    private GameOverHandler gameOverHandler;


    public void Awake(){
        if(instance != null && instance != this){
            Destroy(gameObject);
        }
        else{
            instance = this;
            DontDestroyOnLoad(gameObject);

            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId,testMode);
        }
    }

    public void ShowAd(GameOverHandler g){
        gameOverHandler = g;
        Advertisement.Show("rewardedVideo");

    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log("Error");
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        switch(showResult){
            case ShowResult.Failed:
                Debug.LogWarning("Failed to finish the Ad");
                SceneManager.LoadScene(0);
            break;
            case ShowResult.Finished:
                gameOverHandler.ContinueGame();
                

            break;
            case ShowResult.Skipped:
            
            break;
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {
        Debug.Log("Ad Started");
    }

    public void OnUnityAdsReady(string placementId)
    {
        Debug.Log("Ad is Ready");
    }
}
