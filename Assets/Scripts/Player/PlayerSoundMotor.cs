using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PlayerSoundMotor : MonoBehaviour
{
    private void OnEnable()
    {
        LevelManager.OnMotorSoundOff += OffSoundMotor;
    }
    private void OnDisable()
    {
        LevelManager.OnMotorSoundOff -= OffSoundMotor;
    }
    private void OffSoundMotor()
    {
        gameObject.GetComponent<AudioSource>().volume = 0f;
    }
}
