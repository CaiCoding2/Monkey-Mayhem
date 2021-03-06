﻿using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using System.Xml.Schema;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text bananaText;
    Text scoreText;
    Text timeText;
    Text totalText;
    Text timeCountdownText;

    public static float countdownSeconds = 31;
    public static int bananaAmount;
    public static float score;
    public static int seconds;
    public static int total = 0;

    private float realSeconds = 0;
    
    void Start()
    {
        int total = 0;
        bananaText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        timeText = GetComponent<Text>();
        totalText = GetComponent<Text>();
        timeCountdownText = GetComponent<Text>();
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

        if (this.CompareTag("Total"))
        {
            total = Mathf.FloorToInt(score) + (bananaAmount*5);
            totalText.text = total.ToString();
        }
        
        if (this.CompareTag("TimeCountdown"))
        {
            if (!GameUI.isGameOver && countdownSeconds > 1)
            {
                countdownSeconds -= Time.deltaTime;
            }
            seconds = Mathf.FloorToInt(countdownSeconds);
            timeText.text = seconds.ToString();
        }
    }
    
}
