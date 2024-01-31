using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class ShopItemView : MonoBehaviour, IPointerClickHandler
{
    public event Action<ShopItemView> Click;

    [SerializeField] private Sprite _standardBackground;
    [SerializeField] private Sprite _highlightBackground;

    [SerializeField] private Image _contentImage;
    [SerializeField] private Image _lockImage;

    [SerializeField] private IntValueView _priceView;

    [SerializeField] private Image _selectionText;

    private Image _backgroundImage;

    public ShopItem Item { get; private set; }
    public string Name { get; private set; }
    public bool IsLock { get; private set; }
    public int Price => Item.Price;


    public void Initialize(ShopItem item)
    {
        _backgroundImage = GetComponent<Image>();
        Name = item.Name;
        _backgroundImage.sprite = _standardBackground;
        Item = item;
        _contentImage.sprite = item.leftRightImage;

        _priceView.Show(Price);
    }
    public void OnPointerClick(PointerEventData eventData) => Click?.Invoke(this);

    
    public void Select() => _selectionText.gameObject.SetActive(true);
    public void Unselect() => _selectionText.gameObject.SetActive(false);

    public void Highlight() => _backgroundImage.sprite = _highlightBackground; 
    public void UnHighlight() => _backgroundImage.sprite = _standardBackground;

    public void Unlock()
    {
        IsLock = false;
        _lockImage.gameObject.SetActive(false);
        _priceView.Hide();
    }
}
