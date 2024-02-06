using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

[RequireComponent(typeof(Button))]
public class SkipLevelAdBehavior : MonoBehaviour
{
    private Button buttonSkipAd;
    public static Action OnAdClick;
    public static Action OnButtonClickSound;
    private void Awake()
    {
        buttonSkipAd = gameObject.GetComponent<Button>();
        buttonSkipAd.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
    }
    void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
    void Rewarded(int id)
    {
        switch (id)
        {
            case 1:
                OnButtonClickSound();
                OnAdClick(); //win
                break;
            default:
                break;
        }
    }
}
