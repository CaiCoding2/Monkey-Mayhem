using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    Text bananaText;
    Text scoreText;
    
    public static int bananaAmount;
    public static float score;

    void Start()
    {
        bananaText = GetComponent<Text>();
        scoreText = GetComponent<Text>();
        
    }

    private void Update()
    {
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
