using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="ShopItemViewFactory", menuName ="Shop/ShopItemViewFactory")]
public class ShopItemViewFactory : ScriptableObject
{
    [SerializeField] private ShopItemView _characterSkinItemPrefab;

    //patternFabric
    public ShopItemView Get(ShopItem shopItem, Transform parent)
    {
        ShopItemView instance;

        switch(shopItem)
        {
            case CharacterSkinItem characterSkinItem:
                instance = Instantiate(_characterSkinItemPrefab, parent);

            break;
            default:
                throw new ArgumentException(nameof(shopItem));
        }
        instance.Initialize(shopItem);
        return instance;
    }
}
    
