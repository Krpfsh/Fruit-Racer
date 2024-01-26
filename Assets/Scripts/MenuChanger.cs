using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuChanger : MonoBehaviour
{
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("Main Scene");
    }
    public void RestartGameScene()
    {
        SceneManager.LoadScene("Game Scene");
    }
    public void GoToShopScene()
    {
        SceneManager.LoadScene("Shop Scene");
    }
    public void OffBonus()
    {
        if (MenuManager.LevelId < MenuManager.LevelsLength)
        {
            SceneManager.LoadScene("Game Scene");
        }
        else
        {
            SceneManager.LoadScene("Main Scene");
        }
    }
    public void NextScene()
    {
        SceneManager.LoadScene("Bonus Scene");
    }
}
