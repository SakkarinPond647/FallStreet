﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScorePerSecond : MonoBehaviour
{
    public Text scoreText;
    public Text scoreEndText;
    public Text highScoreText;
    public float scoreAmount = 0;
    public float pointIncreasedPerSec;

    public float highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore", 0);
        scoreAmount = 0f;
        pointIncreasedPerSec = 1f;
        //highScoreText.text = "High score record : " + highscore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        scoreAmount += pointIncreasedPerSec * Time.deltaTime;
        scoreText.text = (int)scoreAmount + " ";
        scoreEndText.text = "Your score : " + (int)scoreAmount;

        if(highscore < scoreAmount)
        {
            PlayerPrefs.SetFloat("highscore", scoreAmount);
        }

        highScoreText.text = "High score record : " + Mathf.RoundToInt(highscore).ToString();

    }
}
