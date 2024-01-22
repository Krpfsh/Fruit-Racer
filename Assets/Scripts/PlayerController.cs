using GG.Infrastructure.Utils.Swipe;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private SwipeListener swipeListener;
    [SerializeField] private RectTransform playerRectTransform;
    private float playerSpeed = 1f;
    [SerializeField] private Sprite[] _playerSprites;

    private Vector2 playerDirection = Vector2.zero;

    private void OnEnable()
    {
        swipeListener.OnSwipe.AddListener(OnSwipe);
    }
    private void OnSwipe(string swipe)
    {
        switch (swipe)
        {
            case "Left":
                playerDirection = Vector2.left;
                gameObject.GetComponent<Image>().sprite = _playerSprites[1];
                break;
            case "Right":
                playerDirection = Vector2.right;
                gameObject.GetComponent<Image>().sprite = _playerSprites[3];
                break;
            case "Up":
                playerDirection = Vector2.up;
                gameObject.GetComponent<Image>().sprite = _playerSprites[2];
                break;
            case "Down":
                playerDirection = Vector2.down;
                gameObject.GetComponent<Image>().sprite = _playerSprites[0];
                break;
        }
    }
    private void Update()
    {
        playerRectTransform.position += (Vector3)playerDirection * playerSpeed * Time.deltaTime;
    }
    private void OnDisable()
    {
        swipeListener.OnSwipe.RemoveListener(OnSwipe);
    }
}
