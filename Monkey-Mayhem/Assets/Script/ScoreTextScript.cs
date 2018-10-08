using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text bananaText;
    Text scoreText;
    Text timeText;
    Text totalScoreText;
    
    public static int bananaAmount;
    public static float score;
    public static int seconds;
    public static int totalScore;

    private float realSeconds = 0;
    
    void Start()
    {
        //score = 0;
        totalScore = 0;
        bananaText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        timeText = GetComponent<Text>();
        totalScoreText = GetComponent<Text>();
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
            totalScore = Mathf.FloorToInt(score) + bananaAmount;
            scoreText.text = totalScore.ToString();
        }
    }
    
}
