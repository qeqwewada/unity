using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class MusicManager : MonoBehaviour
{
    private static readonly object padlock = new object();
    public static MusicManager instance;
    private AudioSource sfx;
    public AudioClip[] musicClips;
    public AudioClip[] buttonClips;

    private Dictionary<string, AudioClip> musicDict;
    private Dictionary<string, AudioClip> sfxDict;
    private List<AudioSource> musicSources;

    void Awake()
    {
        // 确保只有一个实例，并在场景切换时不被销毁
        lock (padlock)
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeDictionaries();
                musicSources = new List<AudioSource>();
                sfx = gameObject.AddComponent<AudioSource>();
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void InitializeDictionaries()
    {
        musicDict = new Dictionary<string, AudioClip>();
        foreach (var clip in musicClips)
        {
            musicDict[clip.name] = clip;
        }

        sfxDict = new Dictionary<string, AudioClip>();
        foreach (var clip in buttonClips)
        {
            sfxDict[clip.name] = clip;
        }
    }

    public void PlayMusic(string name, bool isLoop = false)
    {
        if (musicDict.TryGetValue(name, out var clip))
        {
            AudioSource newMusicSource = gameObject.AddComponent<AudioSource>();
            newMusicSource.clip = clip;
            newMusicSource.loop = isLoop;
            newMusicSource.Play();
            musicSources.Add(newMusicSource);

            if (!isLoop)
            {
                StartCoroutine(DestroyAudioSourceAfterPlay(newMusicSource));
            }
        }
        else
        {
            Debug.LogWarning("未找到名字为 " + name + " 的音乐剪辑");
        }
    }

    private IEnumerator DestroyAudioSourceAfterPlay(AudioSource audioSource)
    {
        yield return new WaitForSeconds(audioSource.clip.length);
        musicSources.Remove(audioSource);
        Destroy(audioSource);
    }

    public void StopMusic(string name)
    {
        for (int i = musicSources.Count - 1; i >= 0; i--)
        {
            if (musicSources[i].clip.name == name)
            {
                musicSources[i].Stop();
                Destroy(musicSources[i]);
                musicSources.RemoveAt(i);
            }
        }
    }

    public void PlaySFX(string name, float volume = 3.0f)
    {
        if (sfxDict.TryGetValue(name, out var clip))
        {
            sfx.PlayOneShot(clip, volume);
        }
        else
        {
            Debug.LogWarning("未找到名字为 " + name + " 的音效剪辑");
        }
    }

        public void SetMusicVolume(float volume)
    {
        foreach (var source in musicSources)
        {
            source.volume = volume;
        }
    }

    // 新增方法：设置音效音量
    public void SetSFXVolume(float volume)
    {
        sfx.volume = volume;
    }
}

public class MusicConst
{
    public static string LoadClip = "LoadClip";
    public static string LogoClip = "LogoClip";
    public static string HomeClip = "HomeClip";
    public static string OpenDoorClip = "OpenDoorClip";
    public static string LoadingStart = "LoadingStart";
    public static string LoadingClip = "LoadingClip";
    public static string LoadSuccess = "LoadSuccess";
    public static string ShopClip = "ShopClip";
    public static string LevelsClip = "LevelsClip";
    public static string StartOver = "StartOver";
}

public class SFXConst
{
    public static string LoginSFX = "LoginSFX";
    public static string Button1 = "Button1";
    public static string Button2 = "Button2";
    public static string Button3 = "Button3";
}