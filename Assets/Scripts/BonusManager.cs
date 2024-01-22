using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusManager : MonoBehaviour
{
    [SerializeField] private Sprite[] fruitsImages;
    [SerializeField] private GameObject[] fruitsContainer;
    [SerializeField] private Button[] buttons;
    private int buttonsOff = 0;
    private string name1;
    private string name2;
    private string name3;

    [SerializeField] private GameObject winButton;
    [SerializeField] private GameObject moneyWin;

    private void Awake()
    {
        moneyWin.GetComponent<TextMeshProUGUI>().text = "Получи награду!";
        for (int i = 0; i < fruitsContainer.Length; i++)
        {
            fruitsContainer[i].GetComponent<Image>().sprite = fruitsImages[Random.Range(0, fruitsImages.Length)];
        }
    }

    public void ButtonClick(int numberButton)
    {

        if (name1 == null) name1 = fruitsContainer[numberButton].GetComponent<Image>().sprite.name;

        else if (name2 == null) name2 = fruitsContainer[numberButton].GetComponent<Image>().sprite.name;

        else if (name3 == null) name3 = fruitsContainer[numberButton].GetComponent<Image>().sprite.name;
        buttonsOff++;
        if(buttonsOff == 3)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].enabled = false;
            }
            Win();
        }

    }
    private void Win()
    {
        winButton.SetActive(true);
        
        if (name1 == name2 && name1 == name3)
        {
            moneyWin.GetComponent<TextMeshProUGUI>().text = "Вы получили 250 монет!";
            MenuManager.MoneyCount += 250;
            PlayerPrefs.SetInt("Money", MenuManager.MoneyCount);
        }
        else if (name1 == name2 || name1 == name3 || name2 == name3)
        {
            moneyWin.GetComponent<TextMeshProUGUI>().text = "Вы получили 150 монет!";
            MenuManager.MoneyCount += 150;
            PlayerPrefs.SetInt("Money", MenuManager.MoneyCount);
        }
        else
        {
            moneyWin.GetComponent<TextMeshProUGUI>().text = "Не расстраивайся, повезёт в следющий раз!";
        }
    }
}
