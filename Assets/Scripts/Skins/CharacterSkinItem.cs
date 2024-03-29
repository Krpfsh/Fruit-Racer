using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="CharacterSkinItem", menuName = "Shop/CharacterSkinItem")]
public class CharacterSkinItem : ShopItem
{
    [field: SerializeField] public CharacterSkins SkinType { get; private set; }
}
