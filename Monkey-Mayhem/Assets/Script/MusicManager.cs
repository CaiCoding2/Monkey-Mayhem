using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MusicManager : MonoBehaviour
{
    public AudioClip menuTheme;
    public AudioClip level1Theme;
    public AudioClip level2Theme;
    public AudioClip level3Theme;
    public AudioClip level4Theme;

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
                                        || sceneName == "Level 1 D"
                                        || sceneName == "Endless")
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

        else if (sceneName == "Level 3" || sceneName == "Level 3 A" 
                                        || sceneName == "Level 3 B"
                                        || sceneName == "Level 3 C"
                                        || sceneName == "Level 3 D")
        {
            clipToPlay = level3Theme;
        }
        
        else if (sceneName == "Level 4" || sceneName == "Level 4 A" 
                                        || sceneName == "Level 4 B"
                                        || sceneName == "Level 4 C"
                                        || sceneName == "Level 4 D")
        {
            clipToPlay = level4Theme;
        }
        
        if (clipToPlay != null)
        {
            AudioManager.instance.playMusic(clipToPlay, 0f);
            Invoke("PlayMusic", clipToPlay.length);
        }


    }
}
