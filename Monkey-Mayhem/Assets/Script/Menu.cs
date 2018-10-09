using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject creditsHolder;
	public GameObject levelSelectHolder;

	public Slider[] volumeSliders;

	void Start()
	{

		SetMusicVolume(.1f); // music was too loud compared to everything else so I turned it down
		volumeSliders [0].value = AudioManager.instance.masterVolumePercent;
		volumeSliders [1].value = AudioManager.instance.musicVolumePercent;
		volumeSliders [2].value = AudioManager.instance.sfxVolumePercent;

	}
	
	public void PlayLevel1() {
		SceneManager.LoadScene ("Level 1");
		restartScores();
	}
	
	public void PlayLevel1A() {
		restartScores();
		SceneManager.LoadScene ("Level 1 A");
	}
	
	public void PlayLevel1B() {
		restartScores();
		SceneManager.LoadScene ("Level 1 B");
	}

	
	public void Quit() {
		Application.Quit ();
	}

	public void OptionsMenu() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
		creditsHolder.SetActive (false);
		levelSelectHolder.SetActive(false);
	}

	public void MainMenu() {
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		levelSelectHolder.SetActive(false);
	}
	
	public void Credits() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (true);
		levelSelectHolder.SetActive(false);
	}
	
	public void levelSelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		levelSelectHolder.SetActive(true);
	}

	public void SetMasterVolume(float value) {
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Master);
	}

	public void SetMusicVolume(float value) {
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Music);
	}

	public void SetSfxVolume(float value) {
		AudioManager.instance.SetVolume (value, AudioManager.AudioChannel.Sfx);
	}

	public void playClick()
	{
		AudioManager.instance.PlaySound("Click", transform.position, 1);
	}

	public void selectNextButton(Button button)
	{
		button.Select();
	}

	public void selectNextSlider(Slider slider)
	{
		slider.Select();
	}

	public void restartScores()
	{
		ScoreTextScript.countdownSeconds = 31;
		ScoreTextScript.score = 0;
		ScoreTextScript.bananaAmount = 0;
		ScoreTextScript.seconds = 0;
		GameUI.isGameOver = false;
	}
}