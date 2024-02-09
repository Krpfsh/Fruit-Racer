using UnityEngine;
using TMPro;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject _gameOver;
    [SerializeField] private float timeStart = 30;
    private TextMeshProUGUI _timeText;

    public static  Action OnFailed;
    private void Start()
    {
        _timeText = gameObject.GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        if(LevelManager.GameIsStop == false) { 
        if (Mathf.Round(timeStart) != 0)
        {
            timeStart -= Time.deltaTime;
        }
        else
        {
            OnFailed();
        }
        if (Mathf.Round(timeStart) >= 10) _timeText.text = "00:" + Mathf.Round(timeStart).ToString();
        if (Mathf.Round(timeStart) < 10) _timeText.text = "00:0" + Mathf.Round(timeStart).ToString();
        if (Mathf.Round(timeStart) <= 10&& Mathf.Round(timeStart) >= 4) _timeText.color = Color.yellow;
        if (Mathf.Round(timeStart) <= 3) _timeText.color = Color.red;
        }
    }
}