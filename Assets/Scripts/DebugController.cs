using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugController : MonoBehaviour
{
    [SerializeField] bool debug;
    [SerializeField] private int levelcomplets;
    // Start is called before the first frame update
    void Awake()
    {
        if (debug)
        PlayerPrefs.SetInt("LevelComplete", levelcomplets);
    }
}
