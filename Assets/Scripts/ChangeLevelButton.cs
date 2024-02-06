using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ChangeLevelButton : MonoBehaviour
{
    public int LevelId;
    private Button button;
    public static Action OnLevelEnter;
    ChangeLevelButton(int id ) { 
        LevelId = id;
    }

    private void OnEnable()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }
    private void OnDisable()
    {
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        DataScenes.LevelId = LevelId;
        OnLevelEnter();
        SceneManager.LoadScene("Game Scene");
    }
}
