using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBehavior : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = MenuManager.MoneyCount.ToString();
    }
}
