using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class RewardVideo : MonoBehaviour, IUnityAdsListener
{

#if UNITY_IOS
    private string gameId = "4106086";
#elif UNITY_ANDROID
    private string gameId = "4106087";
#endif

    Button myButton;
    public string mySurfacingId = "rewardedVideo";
    public ScorePerSecond score;

    void Start()
    {
        myButton = GetComponent<Button>();

        // Set interactivity to be dependent on the Ad Unit or legacy Placement’s status:
        myButton.interactable = Advertisement.IsReady(mySurfacingId);

        // Map the ShowRewardedVideo function to the button’s click listener:
        if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

        // Initialize the Ads listener and service:
        Advertisement.AddListener(this);
        Advertisement.Initialize(gameId, true);
    }

    // Implement a function for showing a rewarded video ad:
    void ShowRewardedVideo()
    {
        Advertisement.Show(mySurfacingId);
    }

    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, activate the button: 
        if (surfacingId == mySurfacingId)
        {
            myButton.interactable = true;
        }
    }

    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        switch (showResult)
        {
            // Define conditional logic for each ad completion status:
            case ShowResult.Finished:
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                Data.score = score.scoreAmount;
                Data.isRespawn = true;
                break;
            case ShowResult.Skipped:
                break;
            case ShowResult.Failed:
                Debug.LogWarning("The ad did not finish due to an error.");
                break;
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }
}