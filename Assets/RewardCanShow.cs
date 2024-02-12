using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ReviewCanShow : MonoBehaviour
{
    [SerializeField] private Text reviewSentEventText;
    
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
    private void Start()
    {
        YandexGame.ReviewShow(true);
    }

    

    
}