using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

	public Image fadePlane;
	public GameObject gameOverUI;
	public GameObject gameOverText;
	public GameObject pauseMenuUI;
	public GameObject challengeComppleteUI;
	public GameObject completeUI;
    public GameObject completeText;
	public static bool isGameOver;
	public Button buttonToSelectOnGameOver;
	public Button buttonToSelectOnPause;
	public Button buttonToSelectOnChallengeComplete;
	public Button buttonToSelectOnLevelComplete;
	public GameObject[] stars;
	public static bool isPaused = false;

	public static int stars1 = 0;
	public static int stars1A = 0;
	public static int stars1B = 0;
	public static int stars1C = 0;
	public static int stars1D = 0;
	
	void Start ()
	{

		
		FindObjectOfType<Player>().OnDeath += onGameOver;
		FindObjectOfType<Player>().OnChallengeCompletion += onChallengeCompleted;
		FindObjectOfType<Player>().OnLevelCompletion += onLevelCompleted;

	}
	
	void Update () {
		
		if (!gameOverUI.active){
			if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button9))
			{
				if(Time.timeScale == 1)
				{
					isPaused = true;
					pauseMenuUI.SetActive(true);
					buttonToSelectOnPause.Select();
					Time.timeScale = 0;
				} else if (Time.timeScale == 0)
				{
					isPaused = false;
					Time.timeScale = 1;
					pauseMenuUI.SetActive(false);
				}
			}
		}
	}

	void onGameOver()
	{
		isGameOver = true;
		gameOverText.SetActive(true);
		StartCoroutine(gameOverUiControl());
	}

	void onLevelCompleted()
	{	
		AudioManager.instance.PlaySound("Victory", new Vector2 (0,0), 1);
		//buttonToSelectOnLevelComplete.Select();
		StartCoroutine(CompelteUiControl());
		completeText.SetActive(true);
		isGameOver = true;
		for (int x = 0; x < (3 - getStars()) ; x++)
		{
			stars[x].SetActive(false);
		}
	}

	void onChallengeCompleted()
	{
		AudioManager.instance.PlaySound("Victory", new Vector2 (0,0), 1);
		buttonToSelectOnChallengeComplete.Select();
		StartCoroutine(Fade (Color.clear, Color.white,1));
		challengeComppleteUI.SetActive (true);
		isGameOver = true;
		for (int x = 0; x < (3 - getStars()) ; x++)
		{
			stars[x].SetActive(false);
		}
		
	}

	IEnumerator gameOverUiControl()
	{
		yield return new WaitForSeconds(2);
		gameOverUI.SetActive(true);
		buttonToSelectOnGameOver.Select();
		StartCoroutine(Fade (Color.clear, Color.white,1));
		gameOverText.SetActive(false);
	}
	
	IEnumerator CompelteUiControl()
	{
		yield return new WaitForSeconds(2);
		completeUI.SetActive(true);
		buttonToSelectOnLevelComplete.Select();
		StartCoroutine(Fade (Color.clear, Color.white,1));
		completeText.SetActive(false);
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
		isPaused = false;
		Time.timeScale = 1;
		pauseMenuUI.SetActive(false);
	}
	
	public void playClick()
	{
		AudioManager.instance.PlaySound("Click", new Vector2 (0,0), 1);
	}

	private int getStars()
	{
		
		if (SceneManager.GetActiveScene().name == "Level 1")
		{
			if (ScoreTextScript.seconds > 15)
			{
				if (stars1A < 1)
				{
					stars1 = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.seconds < 10)
			{
				stars1 = 3;
				return 3;
			}
			else
			{
				if (stars1A < 2)
				{
					stars1 = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level 1 A")
		{
			if (ScoreTextScript.countdownSeconds < 18)
			{
				if (stars1A < 1)
				{
					stars1A = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 22)
			{
				stars1A = 3;
				return 3;
			}
			else
			{
				if (stars1A < 2)
				{
					stars1A = 2;
					
				}

				return 2;
			}
		}

		if (SceneManager.GetActiveScene().name == "Level 1 B")
		{
			if (ScoreTextScript.countdownSeconds < 20)
			{
				if (stars1B < 1)
				{
					stars1B = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 26)
			{
				stars1B = 3;
				return 3;
			}
			else
			{
				if (stars1B < 2)
				{
					stars1B = 2;
					
				}

				return 2;
			}
		}
		
		return 0;
	}
}
