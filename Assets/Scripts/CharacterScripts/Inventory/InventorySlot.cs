using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    public Item item;
    public StickToCursor stickToCursor;

    [SerializeField] public PotionSlot[] _potionSlot;

    public static int _slotIndex;

    Item copyItem;
    private void Awake()
    {
        _potionSlot = GameObject.FindGameObjectsWithTag("UsePotionSlot").Select(s => s.GetComponent<PotionSlot>()).ToArray();
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.Icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

    }

    public void UseItem()
    {
        if (item != null)
        {
            item.Use();
        }
    }

    public void AddItemToPotionSlot(int index)
    {
        if (_potionSlot[index].Item == null)
        {
            _potionSlot[index].Item = item;

            Inventory.Instance.RemoveSlotItem(item);
            _potionSlot[index].AddItemToPotionSlot();
        }
        
        else if(_potionSlot[index].Item != null && _potionSlot[index].Item.Name == item.Name && (_potionSlot[index].Item.itemAmount + item.itemAmount) <= item.maxStack)
        {
            _potionSlot[index].Item.itemAmount = item.itemAmount + _potionSlot[index].Item.itemAmount;
            _potionSlot[index].ChangeText();
            Inventory.Instance.RemoveSlotItem(item);
        }
        else if(_potionSlot[index].Item != null && _potionSlot[index].Item.Name != item.Name)
        {
            var oldItem = _potionSlot[_slotIndex].Item;
            _potionSlot[_slotIndex].Item = item;
            _potionSlot[_slotIndex].AddItemToPotionSlot();
            Inventory.Instance.RemoveSlotItem(item);
            Inventory.Instance.Add(oldItem);
            oldItem = null;
        }
        
    }
    public void AddItemToPotionSlotButton()
    {
        if (item != null)
        {
            copyItem = item;
            bool itemAlredyInInvetory = false;
            for (int i = 0; i < _potionSlot.Length; i++)
            {
                if (_potionSlot[i].Item != null)
                {
                    if (_potionSlot[i].Item.Name == item.Name && (_potionSlot[i].Item.itemAmount + item.itemAmount) <= item.maxStack)
                    {
                        _potionSlot[i].Item.itemAmount = item.itemAmount + _potionSlot[i].Item.itemAmount;
                        for (int a = 0; a < _potionSlot.Length; a++)
                        {
                            _potionSlot[i].ChangeText();
                        }
                        Inventory.Instance.RemoveSlotItem(item);
                        itemAlredyInInvetory = true;

                    }
                }
            }
            bool emptySpace = false;
            if (!itemAlredyInInvetory)
            {
                for (int i = 0; i < _potionSlot.Length; i++)
                {
                    if (_potionSlot[i].Item == null && !itemAlredyInInvetory)
                    {
                        _potionSlot[i].Item = copyItem;
                        _potionSlot[i].AddItemToPotionSlot();
                        Inventory.Instance.RemoveSlotItem(item);
                        _potionSlot[i].ChangeText();
                        emptySpace = true;
                        itemAlredyInInvetory = true;
                    }
                }
            }
            if (!emptySpace && !itemAlredyInInvetory)
            {
                var oldItem = _potionSlot[_slotIndex].Item;
                _potionSlot[_slotIndex].Item = copyItem;
                _potionSlot[_slotIndex].AddItemToPotionSlot();
                Inventory.Instance.RemoveSlotItem(item);
                _slotIndex++;
                if (_slotIndex == 3)
                {
                    _slotIndex = 0;
                }
                Inventory.Instance.Add(oldItem);
            }
        }
    }

    public void OnRemoveItem()
    {
        Inventory.Instance.Remove(item);
    }
}