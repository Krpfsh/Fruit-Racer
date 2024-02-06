using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextLevel : MonoBehaviour
{
    [SerializeField] private GameObject numberText;

    private void Start()
    {

        gameObject.GetComponent<TextMeshProUGUI>().text = (numberText.GetComponent<ChangeLevelButton>().LevelId+1).ToString();
    }
}
