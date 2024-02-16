using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ReviewCanShow : MonoBehaviour
{
    [SerializeField] private Text reviewSentEventText;
    [SerializeField] private GameObject reviewCanShow;
    private void OnEnable()
    {
        YandexGame.ReviewSentEvent += ActiveReview;
    }
    private void OnDisable()
    {
        YandexGame.ReviewSentEvent -= ActiveReview;
    }
    private void ActiveReview(bool active)
    {
        reviewSentEventText.text = active.ToString();

    }
    private void Awake()
    {
        Time.timeScale = 0;
        LevelManager.GameIsStop = true;
        if (PlayerPrefs.GetInt("RateUs", 0) == 1)
        {
            reviewCanShow.SetActive(false);
            Time.timeScale = 1f;
            LevelManager.GameIsStop = false;
        }
    }
    public void LaterRateUs()
    {
        reviewCanShow.SetActive(false);
        Time.timeScale = 1f;
        LevelManager.GameIsStop = false;
    }
    public void RateUsButton()
    {
        reviewCanShow.SetActive(false);
        PlayerPrefs.SetInt("RateUs", 1);
        YandexGame.ReviewShow(true);
        Time.timeScale = 1;
        LevelManager.GameIsStop = false;
    }

    
}