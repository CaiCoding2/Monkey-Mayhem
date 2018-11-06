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
	public static int stars2 = 0;
	public static int stars3 = 0;
	public static int stars4 = 0;
	public static int starsS = 0;
	public static int stars1A = 0;
	public static int stars1B = 0;
	public static int stars1C = 0;
	public static int stars1D = 0;
	public static int stars1S = 0;
	public static int stars2A = 0;
	public static int stars2B = 0;
	public static int stars2C = 0;
	public static int stars2D = 0;
	public static int stars2S = 0;
	public static int stars3A = 0;
	public static int stars3B = 0;
	public static int stars3C = 0;
	public static int stars3D = 0;
	public static int stars3S = 0;
	public static int stars4A = 0;
	public static int stars4B = 0;
	public static int stars4C = 0;
	public static int stars4D = 0;
	public static int stars4S = 0;
	
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
		//isPaused = true;
		isPaused = false;
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
				if (stars1 < 1)
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
				if (stars1 < 2)
				{
					stars1 = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level 2")
		{
			if (ScoreTextScript.seconds > 15)
			{
				if (stars2 < 1)
				{
					stars2 = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.seconds < 10)
			{
				stars2 = 3;
				return 3;
			}
			else
			{
				if (stars2 < 2)
				{
					stars2 = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level 3")
		{
			if (ScoreTextScript.seconds > 15)
			{
				if (stars3 < 1)
				{
					stars3 = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.seconds < 10)
			{
				stars3 = 3;
				return 3;
			}
			else
			{
				if (stars3 < 2)
				{
					stars3 = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level 4")
		{
			if (ScoreTextScript.seconds > 15)
			{
				if (stars4 < 1)
				{
					stars4 = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.seconds < 10)
			{
				stars4 = 3;
				return 3;
			}
			else
			{
				if (stars4 < 2)
				{
					stars4 = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level S")
		{
			if (ScoreTextScript.seconds > 15)
			{
				if (starsS < 1)
				{
					starsS = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.seconds < 10)
			{
				starsS = 3;
				return 3;
			}
			else
			{
				if (starsS < 2)
				{
					starsS = 2;
					
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
		
		if (SceneManager.GetActiveScene().name == "Level 1 C")
		{
			if (ScoreTextScript.countdownSeconds < 15)
			{
				if (stars1C < 1)
				{
					stars1C = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 22)
			{
				stars1C = 3;
				return 3;
			}
			else
			{
				if (stars1C < 2)
				{
					stars1C = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level 1 D")
		{
			if (ScoreTextScript.countdownSeconds < 10)
			{
				if (stars1D < 1)
				{
					stars1D = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 22)
			{
				stars1D = 3;
				return 3;
			}
			else
			{
				if (stars1D < 2)
				{
					stars1D = 2;
					
				}

				return 2;
			}
		}
		
		if (SceneManager.GetActiveScene().name == "Level 2 A")
		{
			if (ScoreTextScript.countdownSeconds < 7)
			{
				if (stars2A < 1)
				{
					stars2A = 1;
					
				}
				return 1;
			}
			else if (ScoreTextScript.countdownSeconds > 15)
			{
				stars2A = 3;
				return 3;
			}
			else
			{
				if (stars2A < 2)
				{
					stars2A = 2;
					
				}

				return 2;
			}
		}
		
		return 0;
	}
}
