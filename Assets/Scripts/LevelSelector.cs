using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    [SerializeField] private GameObject levelPrefab;
    private int levelCount = 8;

    private void Awake()
    {
        for (int i = 0; i < levelCount; i++)
        {
            GameObject newObject = Instantiate(levelPrefab);
            newObject.name = "Level " + i;
            newObject.GetComponent<ChangeLevelButton>().LevelId = i;
            if(newObject.GetComponent<ChangeLevelButton>().LevelId > PlayerPrefs.GetInt("LevelComplete", 0))
            {
                newObject.GetComponent<Button>().interactable = false;
            }
            else
            {
                newObject.GetComponent<Button>().interactable = true;
            }
            // Назначаем родителя для созданного объекта
            newObject.transform.SetParent(gameObject.transform, false);
        }
    }
}
