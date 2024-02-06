using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using YG;
using System;

public class MoneyAdsAdd : MonoBehaviour
{

    //rewardManager
    [SerializeField] private Button button1000;
    public static Action OnButtonSound;

    private void Start()
    {
        button1000.onClick.AddListener(delegate { ExampleOpenRewardAd(1); });
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
        OnButtonSound();
        YandexGame.RewVideoShow(id);
    }
    void Rewarded(int id)
    {
        switch (id)
        {
            case 1:
                
                AddMoney(1000);

                break;
            default:
                break;
        }
    }


    public void AddMoney(int moneyAdd)
    {
        DataScenes.MoneyCount += moneyAdd;
        MoneyBehavior.UpdateText();
    }
}
