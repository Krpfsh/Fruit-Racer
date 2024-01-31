using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopContent _contentItems;

    [SerializeField] private ShopPanel _shopPanel;

    private void Awake()
    {
        _shopPanel.Show(_contentItems.CharacterSkinItems.Cast<ShopItem>());
    }
}
