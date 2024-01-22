using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLevel : MonoBehaviour
{
    [SerializeField] private GameObject test;

    private void Start()
    {

        gameObject.GetComponent<TextMeshProUGUI>().text = "Уровень " + (test.GetComponent<ChangeLevelButton>().LevelId+1).ToString();
    }
}
