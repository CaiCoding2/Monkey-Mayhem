﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text bananaText;
    Text scoreText;
    Text timeText;
    
    public static int bananaAmount;
    public static float score;
    public static int seconds;

    private float realSeconds = 0;
    
    void Start()
    {
        score = 0;
        bananaText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        timeText = GetComponent<Text>();
    }

    private void Update()
    {
        if (this.CompareTag("Time"))
        {
            if (!GameUI.isGameOver)
            {
                realSeconds += Time.deltaTime;
            }
            seconds = Mathf.FloorToInt(realSeconds);
            timeText.text = seconds.ToString();
        }

        
        if (this.CompareTag("Banana"))
        {
            bananaText.text = bananaAmount.ToString();
        }

        if (this.CompareTag("Score"))
        {
            score = Mathf.FloorToInt(score);
            scoreText.text = score.ToString();
        }
    }
    
}