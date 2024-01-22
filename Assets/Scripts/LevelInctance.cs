using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelInctance : MonoBehaviour
{
    [SerializeField] private GameObject buttonPrefab;

    private void Awake()
    {
        Debug.Log(MenuManager.LevelsLength);
    }
}
