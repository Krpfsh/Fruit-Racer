using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class BGGameMusic : MonoBehaviour
{
    public static BGGameMusic instance;
    private AudioSource audioSrc;

    private void OnEnable()
    {
        LevelManager.OnBGMusicOff += BgSoundOff;
        MenuChanger.OnSoundBgOn += BgSoundOn;
        MenuChanger.OnDestroyGameSound += DestroySound;
    }
    private void OnDisable()
    {
        LevelManager.OnBGMusicOff -= BgSoundOff;
        MenuChanger.OnSoundBgOn -= BgSoundOn;
        MenuChanger.OnDestroyGameSound -= DestroySound;
    }
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            if (SceneManager.GetActiveScene().name == "Game Scene" || SceneManager.GetActiveScene().name == "Bonus Scene")
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DestroySound();
            }
            
        }
        else
        {
            DestroySound();
        }
        
    }
    private void BgSoundOff()
    {
        audioSrc.volume = 0f;
    }
    private void BgSoundOn()
    {
        audioSrc.volume = 0f;
    }
    private void DestroySound()
    {
        Destroy(gameObject);
    }
}
