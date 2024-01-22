using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeLevelButton : MonoBehaviour
{
    public int LevelId;
    private Button button;

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
        MenuManager.LevelId = LevelId;
        SceneManager.LoadScene("Game Scene");
    }
}
