using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{

    public AudioClip level1Theme;
    public AudioClip menuTheme;
    public AudioClip level2Theme;

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
        else if (sceneName == "Level 1" || sceneName == "Level 1 A" 
                                        || sceneName == "Level 1 B"
                                        || sceneName == "Level 1 C"
                                        || sceneName == "Level 1 D")
        {
            clipToPlay = level1Theme;
        }
        else if (sceneName == "Level 2" || sceneName == "Level 2 A" 
                                        || sceneName == "Level 2 B"
                                        || sceneName == "Level 2 C"
                                        || sceneName == "Level 2 D")
        {
            clipToPlay = level2Theme;
        }

        if (clipToPlay != null)
        {
            AudioManager.instance.playMusic(clipToPlay, 2);
            Invoke("PlayMusic", clipToPlay.length);
        }


    }
}
