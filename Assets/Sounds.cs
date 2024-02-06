using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Sounds : MonoBehaviour
{
    public static Sounds instance;
    private AudioSource audioSrc;
    public AudioClip EnterShop;
    public AudioClip EnterLevel;
    public AudioClip BuySkin;


    private void OnEnable()
    {
        MenuChanger.OnShop += EnterShopSound;
        MenuChanger.OnButtonClickSound += ButtonClick;
        ChangeLevelButton.OnLevelEnter += ButtonClick;
        ShopPanel.OnBuySkin += BuySkinSound;
        MoneyAdsAdd.OnButtonSound += ButtonClick;
        SkipLevelAdBehavior.OnButtonClickSound += ButtonClick;
        BonusManager.OnButtonClick += ButtonClick;

    }
    private void OnDisable()
    {
        MenuChanger.OnShop -= EnterShopSound;
        MenuChanger.OnButtonClickSound -= ButtonClick;
        ChangeLevelButton.OnLevelEnter -= ButtonClick;
        ShopPanel.OnBuySkin -= BuySkinSound;
        MoneyAdsAdd.OnButtonSound -= ButtonClick;
        SkipLevelAdBehavior.OnButtonClickSound -= ButtonClick;
        BonusManager.OnButtonClick -= ButtonClick;
    }
    private void Awake()
    {
        audioSrc = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }
    
    public void EnterShopSound()
    {
        audioSrc.clip = EnterShop;
        audioSrc.Play();
    }
    public void ButtonClick()
    {
        audioSrc.clip = EnterLevel;
        audioSrc.Play();
    }
    public void BuySkinSound()
    {
        audioSrc.clip = BuySkin;
        audioSrc.Play();
    }
}
