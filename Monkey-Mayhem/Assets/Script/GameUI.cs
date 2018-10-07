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
	
	void Start ()
	{
		FindObjectOfType<Player>().OnDeath += onGameOver;
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
		ScoreTextScript.bananaAmount = 0;
		SceneManager.LoadScene("Level 1");
	}
}
