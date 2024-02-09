using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcherButton : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    [SerializeField] private GameObject _audListener;

    private void Awake()
    {
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 1)
        {
            gameObject.GetComponent<Image>().sprite = audioOn;
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }
        else
        {
            gameObject.GetComponent<Image>().sprite = audioOff;
            AudioListener.volume = 0;
            AudioListener.pause = true;
        }
    }

    public void ButtonClick()
    {
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 1)
        {
            PlayerPrefs.SetInt("SoundIsOn", 0);
            gameObject.GetComponent<Image>().sprite = audioOff;
            AudioListener.volume = 0;
            AudioListener.pause = true;
        }

        else
        {
            PlayerPrefs.SetInt("SoundIsOn", 1);
            gameObject.GetComponent<Image>().sprite = audioOn;
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }

    }
}
