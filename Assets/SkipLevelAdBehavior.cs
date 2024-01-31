using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SkipLevelAdBehavior : MonoBehaviour
{
    private Button buttonSkipAd;
    public static Action AdClick;
    private void Awake()
    {
        buttonSkipAd = gameObject.GetComponent<Button>();
        buttonSkipAd.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        AdClick();
    }
}
