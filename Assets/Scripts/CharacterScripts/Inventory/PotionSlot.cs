using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
using System;
public class PotionSlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public bool mouse_over;
    [SerializeField] private Image _icon;
    [SerializeField] private Sprite _basicIcon;
    [SerializeField] GameObject _iconGameObjcet;

    public Item Item;
    [SerializeField] private TextMeshProUGUI _potionAmount;

    private Inventory _inventory;
    private void Awake()
    {
        _potionAmount.enabled = false;
    }
    public void AddItemToPotionSlot()
    {
        if(Item != null)
        {
            _icon.sprite = Item.Icon;
            _potionAmount.text = Convert.ToString(Item.itemAmount);
            if(Item.itemAmount >= 2)
            {
                _potionAmount.enabled = true;
            }
        }
    }
    public void RemoveItemFromPotionSlot()
    {
        if(Item != null)
        { 
            Inventory.Instance.Add(Item);
            var icon = _iconGameObjcet.GetComponent<Image>();
            icon.sprite = _basicIcon;
            _potionAmount.enabled = false;
            Item = null;
        }
    }
    public void ChangeText()
    {
        if(Item != null)
        {
            if(Item.itemAmount >= 2)
            {
                _potionAmount.enabled = true;
                _potionAmount.text = Convert.ToString(Item.itemAmount);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        mouse_over = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouse_over = false;
    }
}