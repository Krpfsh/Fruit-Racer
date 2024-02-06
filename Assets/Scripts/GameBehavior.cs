using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBehavior : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;
    public Canvas canvas;
    private void Awake()
    {
        if (DataScenes.LevelId < DataScenes.LevelsLength)
        {
            GameObject newObject = Instantiate(levels[DataScenes.LevelId], Vector3.zero, Quaternion.identity);
            // Установка канваса в качестве родителя для нового объекта
            newObject.transform.SetParent(canvas.transform, false);
        }
    }
}
