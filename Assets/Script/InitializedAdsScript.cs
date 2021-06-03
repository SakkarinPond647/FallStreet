using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements; 

public class InitializedAdsScript : MonoBehaviour
{
    public string gameIdIos = "4106086";
    public string gameIdAndriod = "4106087";
    bool testMode = true;

    // Start is called before the first frame update
    void Start()
    {
        if (Application.platform == RuntimePlatform.Android)
        { Advertisement.Initialize(gameIdAndriod, testMode); }
        else
        { Advertisement.Initialize(gameIdIos, testMode); }
    }
}
