using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

	public Image fadePlane;
	public GameObject gameOverUI;
	public GameObject pauseMenuUI;
	public GameObject challengeComppleteUI;
	public static bool isGameOver;
	public Button buttonToSelectOnGameOver;
	public Button buttonToSelectOnPause;
	public Button buttonToSelectOnChallengeComplete;
	public GameObject[] stars;
	
	
	void Start ()
	{
		
		FindObjectOfType<Player>().OnDeath += onGameOver;
		FindObjectOfType<Player>().OnChallengeCompletion += onChallengeCompleted;

	}
	
	void Update () {

		if (!gameOverUI.active){
			if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button9))
			{
				if(Time.timeScale == 1)
				{
					buttonToSelectOnPause.Select();
					Time.timeScale = 0;
					pauseMenuUI.SetActive(true);
				} else if (Time.timeScale == 0){
					Time.timeScale = 1;
					pauseMenuUI.SetActive(false);
				}
			}
		}
	}

	void onGameOver()
	{
		buttonToSelectOnGameOver.Select();
		StartCoroutine(Fade (Color.clear, Color.white,1));
		gameOverUI.SetActive (true);
		isGameOver = true;
	}

	void onChallengeCompleted()
	{
		buttonToSelectOnChallengeComplete.Select();
		StartCoroutine(Fade (Color.clear, Color.white,1));
		challengeComppleteUI.SetActive (true);
		isGameOver = true;
		for (int x = 0; x < (3 - getStars()) ; x++)
		{
			stars[x].SetActive(false);
		}
		
	}

	IEnumerator Fade(Color from, Color to, float time) {
		float speed = 1 / time;
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * speed;
			fadePlane.color = Color.Lerp(from,to,percent);
			yield return null;
		}
	}
	
	public void StartNewGame()
	{
		isGameOver = false;
		ScoreTextScript.bananaAmount = 0;
		ScoreTextScript.countdownSeconds = 31;
		ScoreTextScript.score = 0;
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1;
	}

	public void toMenu()
	{
		Time.timeScale = 1;
		ScoreTextScript.bananaAmount = 0;
		SceneManager.LoadScene("Menu");
	}

	public void Continue()
	{
		Time.timeScale = 1;
		pauseMenuUI.SetActive(false);
	}
	
	public void playClick()
	{
		AudioManager.instance.PlaySound("Click", new Vector2 (0,0), 1);
	}

	private int getStars()
	{
		if (SceneManager.GetActiveScene().name == "Level 1 A")
		{
			if (ScoreTextScript.countdownSeconds < 18)
			{
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 25)
			{
				return 3;
			}
			else
			{
				return 2;
			}
		}

		if (SceneManager.GetActiveScene().name == "Level 1 B")
		{
			if (ScoreTextScript.countdownSeconds < 22)
			{
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 28)
			{
				return 3;
			}
			else
			{
				return 2;
			}
		}
		
		return 0;
	}
}
