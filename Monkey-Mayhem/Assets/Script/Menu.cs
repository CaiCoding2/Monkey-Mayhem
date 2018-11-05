using UnityEngine;
using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public GameObject mainMenuHolder;
	public GameObject optionsMenuHolder;
	public GameObject creditsHolder;
	public GameObject classicLevelSelectHolder;
	public GameObject playMenuHolder;
	public GameObject challengeLevelSelectHolder;
	public GameObject jungleChallangeSelectHolder;
	public GameObject volcanoChallangeSelectHolder;
	public GameObject skyChallangeSelectHolder;
	public GameObject spaceChallangeSelectHolder;

	public Slider[] volumeSliders;
	
	public GameObject[] stars1A;
	public GameObject[] stars1;

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
	
	public void PlayLevel1C() {
		restartScores();
		SceneManager.LoadScene ("Level 1 C");
	}
	
	public void PlayLevel1D() {
		restartScores();
		SceneManager.LoadScene ("Level 1 D");
	}
	
	public void PlayLevel2() {
		restartScores();
		SceneManager.LoadScene ("Level 2");
	} 
	
	public void PlayLevel2A() {
		restartScores();
		SceneManager.LoadScene ("Level 2 A");
	} 
	
	public void PlayLevel2B() {
		restartScores();
		SceneManager.LoadScene ("Level 2 B");
	} 
	
	public void PlayLevel2C() {
		restartScores();
		SceneManager.LoadScene ("Level 2 C");
	} 
	
	public void PlayLevel2D() {
		restartScores();
		SceneManager.LoadScene ("Level 2 D");
	} 
	
	public void PlayLevel3() {
        restartScores();
        SceneManager.LoadScene ("Level 3");
    }
	
	public void PlayLevel3A() {
		restartScores();
		SceneManager.LoadScene ("Level 3 A");
	}
	
	public void PlayLevel3B() {
		restartScores();
		SceneManager.LoadScene ("Level 3 B");
	}
	
	public void PlayLevel3C() {
		restartScores();
		SceneManager.LoadScene ("Level 3 C");
	}
	
	public void PlayLevel3D() {
		restartScores();
		SceneManager.LoadScene ("Level 3 D");
	}
        
    public void PlayLevel4() {
         restartScores();
         SceneManager.LoadScene ("Level 4");
    }
	
	public void PlayLevel4A() {
		restartScores();
		SceneManager.LoadScene ("Level 4 A");
	}
	
	public void PlayLevel4B() {
		restartScores();
		SceneManager.LoadScene ("Level 4 B");
	}
	
	public void PlayLevel4C() {
		restartScores();
		SceneManager.LoadScene ("Level 4 C");
	}
	
	public void PlayLevel4D() {
		restartScores();
		SceneManager.LoadScene ("Level 4 D");
	}

	public void PlayEndless() {
		restartScores();
		SceneManager.LoadScene ("Endless");
	}
	
	public void Quit() {
		Application.Quit ();
	}

	public void OptionsMenu() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (true);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
		
	}

	public void MainMenu() {
		mainMenuHolder.SetActive (true);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void PlaynMenu() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(true);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void Credits() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (true);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void classicLevelSelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(true);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
		displayStars1();
	}
	
	public void challegeLevelSelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(true);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void jungleSelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(true);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void volcanoSelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(true);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void skySelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(true);
		spaceChallangeSelectHolder.SetActive(false);
	}
	
	public void spaceSelect() {
		mainMenuHolder.SetActive (false);
		optionsMenuHolder.SetActive (false);
		creditsHolder.SetActive (false);
		classicLevelSelectHolder.SetActive(false);
		playMenuHolder.SetActive(false);
		challengeLevelSelectHolder.SetActive(false);
		jungleChallangeSelectHolder.SetActive(false);
		volcanoChallangeSelectHolder.SetActive(false);
		skyChallangeSelectHolder.SetActive(false);
		spaceChallangeSelectHolder.SetActive(true);
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
		GameUI.isPaused = false;
	}

	public void displayStars1A()
	{
		for (int x = 0 ; x < GameUI.stars1A; x++)
		{
			stars1A[x].SetActive(true);
		}
	}

	public void displayStars1()
	{
		for (int x = 0 ; x < GameUI.stars1; x++)
		{
			stars1[x].SetActive(true);
		}
	}
	
}