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
	
	void Start ()
	{
		FindObjectOfType<Player>().OnDeath += onGameOver;
	}
	
	void Update () {

		if (!gameOverUI.active){
			if(Input.GetKeyDown(KeyCode.P))
			{
				if(Time.timeScale == 1)
				{
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
		StartCoroutine(Fade (Color.clear, Color.white,1));
		gameOverUI.SetActive (true);
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
		Time.timeScale = 1;
		ScoreTextScript.bananaAmount = 0;
		SceneManager.LoadScene("Level 1");
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
}
