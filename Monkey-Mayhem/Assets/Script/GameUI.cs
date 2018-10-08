using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{

	public Image fadePlane;
	public Image fadePlane2;
	public GameObject gameOverUI;
	public GameObject pauseMenuUI;
	public static bool isGameOver;
	public Button buttonToSelectOnGameOver;
	public Button buttonToSelectOnPause;
	
	void Start ()
	{
		FindObjectOfType<Player>().OnDeath += onGameOver;
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

	IEnumerator Fade(Color from, Color to, float time) {
		float speed = 1 / time;
		float percent = 0;

		while (percent < 1) {
			percent += Time.deltaTime * speed;
			fadePlane.color = Color.Lerp(from,to,percent);
			fadePlane2.color = Color.Lerp(from,to,percent);
			yield return null;
		}
	}
	
	public void StartNewGame()
	{
		isGameOver = false;
		ScoreTextScript.bananaAmount = 0;
		ScoreTextScript.score = 0;
		SceneManager.LoadScene("Level 1");
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
}
