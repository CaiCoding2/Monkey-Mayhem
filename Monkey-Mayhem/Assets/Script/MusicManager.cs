using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{

    public AudioClip level1Theme;
    public AudioClip menuTheme;

    string sceneName;

    
    void Start() {
        OnLevelWasLoaded (0);
    }


    void OnLevelWasLoaded(int sceneIndex) {
        string newSceneName = SceneManager.GetActiveScene ().name;
        if (newSceneName != sceneName) {
            sceneName = newSceneName;
            Invoke ("PlayMusic", .2f);
        }
    }
    
    void PlayMusic()
    {
        AudioClip clipToPlay = null;

        if (sceneName == "Menu")
        {
            clipToPlay = menuTheme;
        }
        else if (sceneName == "Level 1")
        {
            clipToPlay = level1Theme;
        }

        if (clipToPlay != null)
        {
            AudioManager.instance.playMusic(clipToPlay, 2);
            Invoke("PlayMusic", clipToPlay.length);
        }


    }
}
