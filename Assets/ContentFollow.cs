using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContentFollow : MonoBehaviour
{
    private RectTransform _contentRect;
    private void Awake()
    {
        _contentRect = GetComponent<RectTransform>();
        _contentRect.anchoredPosition = new Vector2( _contentRect.anchoredPosition.x, PlayerPrefs.GetInt("LevelComplete", 0) * 100 + 90);
        Debug.Log(_contentRect.anchoredPosition.y);
    }
}
