using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChanger : MonoBehaviour
{

    public static Action OnShop;
    public static Action OnButtonClickSound;
    public static Action OnDestroyGameSound;
    public static Action OnSoundBgOn;
    public void GoToMainMenuGame()
    {
        OnButtonClickSound();
        OnDestroyGameSound();
        SceneManager.LoadScene("Main Scene");
    }
    public void GoToMainMenuShop()
    {
        OnButtonClickSound();
        SceneManager.LoadScene("Main Scene");
    }
    public void RestartGameScene()
    {
        OnButtonClickSound();
        SceneManager.LoadScene("Game Scene");
    }
    public void GoToShopScene()
    {
        OnShop();
        OnDestroyGameSound();
        SceneManager.LoadScene("Shop Scene");
    }
    public void OffBonus()
    {
        OnButtonClickSound();
        OnSoundBgOn();
        DataScenes.LevelId++;
        if (DataScenes.LevelId < DataScenes.LevelsLength)
        {
            Debug.Log(DataScenes.LevelId + " "+DataScenes.LevelsLength);
            
            SceneManager.LoadScene("Game Scene");
        }
        else
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
    public void NextScene()
    {
        OnButtonClickSound();
        SceneManager.LoadScene("Bonus Scene");
    }
}
