using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShopItem : ScriptableObject
{
    //[field: SerializeField] public GameObject Model { get; private set; }
    [field: SerializeField] public Sprite frontImage { get; private set; }
    [field: SerializeField] public Sprite rightLeftImage { get; private set; }
    [field: SerializeField] public Sprite backImage { get; private set; }
    [field: SerializeField] public Sprite leftRightImage { get; private set; }
    [field: SerializeField] public string Name { get; private set; }
    [field: SerializeField, Range (0, 10000)] public int Price { get; private set; }
}
