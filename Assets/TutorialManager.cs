using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private void Awake()
    {
        Time.timeScale = 0f;
    }

    public void ButtonTutorialClick()
    {
        Time.timeScale = 1f;
        gameObject.SetActive(false);
    }
}
