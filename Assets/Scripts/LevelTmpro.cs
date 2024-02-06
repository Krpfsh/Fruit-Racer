using TMPro;
using UnityEngine;

public class LevelTmpro : MonoBehaviour
{
    private void Awake()
    {
        gameObject.GetComponent<TextMeshProUGUI>().text =  (DataScenes.LevelId + 1).ToString();
    }
}
