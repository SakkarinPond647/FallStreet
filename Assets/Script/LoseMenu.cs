using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class LoseMenu : MonoBehaviour
{
    string placementId = "video";

    void Start()
    {
        
    }


    public void RestartScene()
    {
        Data.score = 0;
        Data.round = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BacktScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}
