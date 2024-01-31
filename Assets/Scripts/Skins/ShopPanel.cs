using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopPanel : MonoBehaviour
{
    private List<ShopItemView> _shopItems = new List<ShopItemView>();

    [SerializeField] private Transform _itemParent;
    [SerializeField] private ShopItemViewFactory _shopItemViewFactory;

    private void Start()
    {
        PlayerPrefs.SetString("DefaultCar", "true");
        foreach (var item in _shopItems)
        {
            //ѕеребирает все скины и открывает, у которых true
            if (PlayerPrefs.GetString($"{item.Name}") == "true"){
                item.Unlock();
            }
            //ѕеребирает все скины и выбирает 
            if(PlayerPrefs.GetString("Selected", "DefaultCar") == item.Name)
            {
                item.Select();
                item.Highlight();
                item.Unlock();
            }
        }
        
    }
    public void Show(IEnumerable<ShopItem> items)
    {
        Clear();
        foreach (ShopItem item in items)
        {
            ShopItemView spawnedItem = _shopItemViewFactory.Get(item, _itemParent);

            spawnedItem.Click += OnItemViewClick;

            spawnedItem.Unselect();
            spawnedItem.UnHighlight();

            //ѕроверка открытости скины и тп

            _shopItems.Add(spawnedItem);
        }
    }

    private void OnItemViewClick(ShopItemView view)
    {
        //ѕроверка куплен ли у нас скин
        if(PlayerPrefs.GetString($"{view.Name}") == "true")
        {
            //куплен
            PlayerPrefs.SetString("Selected", view.Name);
            foreach (var item in _shopItems)
            {
                item.Unselect();
                item.UnHighlight();
            }
            view.Select();
            view.Highlight();
            view.Unlock();
        }
        else
        {
            //не куплен 
            //хватает ли нам денег
            if (view.Price <= MenuManager.MoneyCount)
            {
                MenuManager.MoneyCount -= view.Price;
                MoneyBehavior.UpdateText();
                PlayerPrefs.SetString($"{view.Name}", "true");
                PlayerPrefs.SetString("Selected", view.Name);
                foreach (var item in _shopItems)
                {
                    item.Unselect();
                    item.UnHighlight();
                }
                view.Select();
                view.Highlight();
                view.Unlock();
            }
            else
            {
                //недостаточно денег
            }
        }
        
    }

    private void Clear()
    {
        foreach(ShopItemView item in _shopItems)
        {
            item.Click -= OnItemViewClick;
            Destroy(item.gameObject);
        }
        _shopItems.Clear();
    }
}
