using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    public Canvas canvas;
    private void Awake()
    {
        MenuManager.LevelsLength = levels.Length;
        if (MenuManager.LevelId < MenuManager.LevelsLength)
        {
            GameObject newObject = Instantiate(levels[MenuManager.LevelId], Vector3.zero, Quaternion.identity);
            // Установка канваса в качестве родителя для нового объекта
            newObject.transform.SetParent(canvas.transform, false);
        }
    }
}
