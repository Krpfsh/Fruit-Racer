using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] _fruitsCart1;
    [SerializeField] private GameObject[] _fruitsCart2;
    [SerializeField] private GameObject[] _fruitsCart3;
    [SerializeField] private TextMeshProUGUI _fruitsCollected;
    [SerializeField] private GameObject _player;

    [SerializeField] private GameObject _winWindow;
    [SerializeField] private GameObject _loseWindow;

    [SerializeField] private Image[] _carts;
    public static bool IsActiveCart1 = true;
    public static bool IsActiveCart2 = false;
    public static bool IsActiveCart3 = false;

    private int _fruitNumber;

    private int win;
    private int _moneyWin = 100;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        _fruitNumber = _fruitsCart1.Length + _fruitsCart2.Length + _fruitsCart3.Length;
        UpdateCollectedFruitsText();
        CartChanger(0);
    }
    public void Accept()
    {
        win++;
        UpdateCollectedFruitsText();
        Win();
    }
    private void Win()
    {
        if (win == _fruitNumber)
        {
            OffPlayerMove();
            Time.timeScale = 0f;
            if (MenuManager.LevelId >= PlayerPrefs.GetInt("LevelComplete", 0))
            {
                PlayerPrefs.SetInt("LevelComplete", PlayerPrefs.GetInt("LevelComplete", 0)+1);
            }
            MenuManager.MoneyCount += _moneyWin;
            _winWindow.SetActive(true);
        }
    }
    public void Failed()
    {
        OffPlayerMove();
        Time.timeScale = 0f;
        _loseWindow.SetActive(true);
    }
    public void CartChanger(int cartNumber)
    {
        if (IsActiveCart2 == null) return;
        if (IsActiveCart3 == null) return;

        switch (cartNumber)
        {
            case 0:
                for (int i = 0; i < _carts.Length; i++)
                {
                    _carts[i].enabled = false;
                    _carts[cartNumber].enabled = true;
                }
                IsActiveCart1 = true;
                IsActiveCart2 = false;
                IsActiveCart3 = false;
                break;
            case 1:
                for (int i = 0; i < _carts.Length; i++)
                {
                    _carts[i].enabled = false;
                    _carts[cartNumber].enabled = true;
                }
                IsActiveCart1 = false;
                IsActiveCart2 = true;
                IsActiveCart3 = false;
                break;
            case 2:
                for (int i = 0; i < _carts.Length; i++)
                {
                    _carts[i].enabled = false;
                    _carts[cartNumber].enabled = true;
                }
                IsActiveCart1 = false;
                IsActiveCart2 = false;
                IsActiveCart3 = true;
                break;
            default:
                break;
        }
        

    }
    private void UpdateCollectedFruitsText()
    {
        _fruitsCollected.text = win + "/" + _fruitNumber;
    }
    private void OffPlayerMove()
    {
        _player.GetComponent<PlayerController>().enabled = false;
    }
    private void OnEnable()
    {
        Timer.OnFailed += Failed;
        OnCollideSimple.OnFailed += Failed;
        OnCollideSimple.OnAccept += Accept;
    }
    private void OnDisable()
    {
        Timer.OnFailed -= Failed;
        OnCollideSimple.OnFailed -= Failed;
        OnCollideSimple.OnAccept -= Accept;
    }

}
