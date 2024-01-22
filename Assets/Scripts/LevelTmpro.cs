using TMPro;
using UnityEngine;

public class LevelTmpro : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text = "LVL " + (MenuManager.LevelId + 1);
    }
}
