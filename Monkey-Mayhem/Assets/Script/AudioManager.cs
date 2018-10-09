using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioChannel
    {
        Master,
        Sfx,
        Music
    };
    
    public float masterVolumePercent  { get; private set; }
    public float sfxVolumePercent  { get; private set; }
    public float musicVolumePercent { get; private set; }

    AudioSource[] musicSources;
    int activeMusicSourceIndex;

    SoundLibrary library;

    public static AudioManager instance;
    
    void Awake()
    {  
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);

            library = GetComponent<SoundLibrary>();
        
            musicSources = new AudioSource[2];
            for (int i = 0; i < 2; i++)
            {
                GameObject newMusicSource = new GameObject("Music source "  + (i+1));
                musicSources[i] = newMusicSource.AddComponent<AudioSource>();
                newMusicSource.transform.parent = transform;
            }
            
            masterVolumePercent = PlayerPrefs.GetFloat("master vol", 1);
            sfxVolumePercent = PlayerPrefs.GetFloat("sfx vol", 1);
            musicVolumePercent = PlayerPrefs.GetFloat("music vol", 1);
            PlayerPrefs.Save();
        }
    }

    public void SetVolume(float volumePercent, AudioChannel channel)
    {
        switch (channel)
        {
            case AudioChannel.Master:
                masterVolumePercent = volumePercent;
                break;
            case AudioChannel.Sfx:
                sfxVolumePercent = volumePercent;
                break;
            case AudioChannel.Music:
                musicVolumePercent = volumePercent;
                break;
        }

        musicSources[0].volume = musicVolumePercent * masterVolumePercent;
        musicSources[1].volume = musicVolumePercent * masterVolumePercent;
        
        PlayerPrefs.SetFloat("master vol", 1);
        PlayerPrefs.SetFloat("sfx vol", 1);
        PlayerPrefs.SetFloat("music vol", 1);
        PlayerPrefs.Save();
    }

    public void playMusic(AudioClip clip, float fadeDuration)
    {
        
        activeMusicSourceIndex = 1 - activeMusicSourceIndex;        
        musicSources[activeMusicSourceIndex].clip = clip;        
        musicSources[activeMusicSourceIndex].Play();

        StartCoroutine(AnimateMusicCrossFade(fadeDuration));
    }

    public void PlaySound(AudioClip clip, Vector3 pos, float soundMultiply)
    {
        //AudioSource.PlayClipAtPoint(clip, pos, (sfxVolumePercent * soundMultiply) * masterVolumePercent);
    }

    public void PlaySound(string soundName, Vector3 pos, float soundMultiply)
    {
        PlaySound(library.GetClipFromName(soundName), pos, soundMultiply);
    }

    IEnumerator AnimateMusicCrossFade(float duration)
    {
        float percent = 0;

        while (percent < 1)
        {
            percent += Time.deltaTime * 1 / duration;
            musicSources[activeMusicSourceIndex].volume =
                Mathf.Lerp(0, musicVolumePercent * masterVolumePercent, percent);
            musicSources[1 - activeMusicSourceIndex].volume =
                Mathf.Lerp(musicVolumePercent * masterVolumePercent, 0, percent);
            yield return null;
        }
    }
}
