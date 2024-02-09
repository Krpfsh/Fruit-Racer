using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioListenerOff : MonoBehaviour
{
    private void Awake()
    {
        SwitchAudioListener();
    }
    public void SwitchAudioListener()
    {
        if (PlayerPrefs.GetInt("SoundIsOn", 1) == 1)
        {
            gameObject.GetComponent<AudioListener>().enabled = true;
            AudioListener.volume = 1;
            AudioListener.pause = false;
        }
        else
        {
            gameObject.GetComponent<AudioListener>().enabled = false;
            AudioListener.volume = 0;
            AudioListener.pause = true;
        }
    }
}
