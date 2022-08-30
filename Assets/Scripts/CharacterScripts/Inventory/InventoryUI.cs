using UnityEngine;
using System.Linq;
using TMPro;
using System;
public class InventoryUI : MonoBehaviour
{
    private Inventory _inventory;
    public static InventoryUI instanceUI;
    private TextMeshProUGUI[] _itemAmountText;

     private TextMeshProUGUI[] _itemWeaponAmountText;
     private InventorySlot[] _weaponSlots;
     private TextMeshProUGUI[] _itemApperanceAmountText;
     private InventorySlot[] _apperanceSlots;
     private TextMeshProUGUI[] _itemPotionAmountText;
     private InventorySlot[] _potionSlots;
     private TextMeshProUGUI[] _itemFoodAmountText;
     private InventorySlot[] _foodSlots;
     private TextMeshProUGUI[] _itemBookAmountText;
     private InventorySlot[] _bookSlots;
     private TextMeshProUGUI[] _itemIngridienAmountText;
     private InventorySlot[] _ingridiensSlots;


    #region Singeton
    void Awake()
    {
        if (instanceUI != null)
        {
            Debug.Log("Error: More than one instance of Inventory found");
            return;
        }
        instanceUI = this;

        _inventory = Inventory.Instance;
        _inventory.onItemChangedCallback += UpdateUI;

        _weaponSlots = GameObject.FindGameObjectsWithTag("weaponSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _apperanceSlots = GameObject.FindGameObjectsWithTag("apperanceSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _potionSlots = GameObject.FindGameObjectsWithTag("potionSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _foodSlots = GameObject.FindGameObjectsWithTag("foodSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _bookSlots = GameObject.FindGameObjectsWithTag("bookSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _ingridiensSlots = GameObject.FindGameObjectsWithTag("ingridiensSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();

        _itemWeaponAmountText = GameObject.FindGameObjectsWithTag("itemWeaponAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
        _itemApperanceAmountText = GameObject.FindGameObjectsWithTag("itemApperanceAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
        _itemPotionAmountText = GameObject.FindGameObjectsWithTag("itemPotionAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
        _itemFoodAmountText = GameObject.FindGameObjectsWithTag("itemFoodAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
        _itemBookAmountText = GameObject.FindGameObjectsWithTag("itemBookAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
        _itemIngridienAmountText = GameObject.FindGameObjectsWithTag("itemIngridiensAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
    }
    #endregion
    void UpdateUI()
    {
        for (var i = 0; i < _weaponSlots.Length; i++)
        {
            if (i < _inventory.weaponItems.Count)
            {
                if (_inventory.weaponItems[i].itemAmount >= 2)
                {
                    _itemWeaponAmountText[i].enabled = true;
                    ChangeItemsAmountText();
                }
                else
                {
                    ChangeItemsAmountText();
                    _itemWeaponAmountText[i].enabled = false;
                }
                _weaponSlots[i].AddItem(_inventory.weaponItems[i]);

            }
            else
            {
                _weaponSlots[i].ClearSlot();
                if (i < _inventory.weaponItems.Count)
                {
                    ChangeItemsAmountText();
                }
                _itemWeaponAmountText[i].enabled = false;
            }
        }
        for (var i = 0; i < _apperanceSlots.Length; i++)
        {
            if (i < _inventory.apperanceItems.Count)
            {
                if (_inventory.apperanceItems[i].itemAmount >= 2)
                {
                    _itemApperanceAmountText[i].enabled = true;
                    ChangeItemsAmountText();
                }
                else
                {
                    _itemApperanceAmountText[i].enabled = false;
                    ChangeItemsAmountText();
                }
                _apperanceSlots[i].AddItem(_inventory.apperanceItems[i]);
            }
            else
            {
                if (i < _inventory.apperanceItems.Count)
                {
                    ChangeItemsAmountText();
                }
                _itemApperanceAmountText[i].enabled = false;
                _apperanceSlots[i].ClearSlot();
            }

        }
        for (var i = 0; i < _potionSlots.Length; i++)
        {
            if (i < _inventory.potionItems.Count)
            {
                if (_inventory.potionItems[i].itemAmount >= 2)
                {
                    _itemPotionAmountText[i].enabled = true;
                    ChangeItemsAmountText();
                }
                else
                {
                    ChangeItemsAmountText();
                    _itemPotionAmountText[i].enabled = false;
                }
                _potionSlots[i].AddItem(_inventory.potionItems[i]);
            }
            else
            {
                if (i < _inventory.potionItems.Count)
                {
                    ChangeItemsAmountText();
                }
                _itemPotionAmountText[i].enabled = false;
                _potionSlots[i].ClearSlot();
            }

        }
        for (var i = 0; i < _foodSlots.Length; i++)
        {
            if (i < _inventory.foodItems.Count)
            {
                if (_inventory.foodItems[i].itemAmount >= 2)
                {
                    _itemFoodAmountText[i].enabled = true;
                    ChangeItemsAmountText();
                }
                else
                {
                    _itemFoodAmountText[i].enabled = false;
                    ChangeItemsAmountText();
                }
                _foodSlots[i].AddItem(_inventory.foodItems[i]);
            }
            else
            {
                if (i < _inventory.foodItems.Count)
                {
                    ChangeItemsAmountText();
                }
                _itemFoodAmountText[i].enabled = false;
                _foodSlots[i].ClearSlot();
            }

        }
        for (var i = 0; i < _bookSlots.Length; i++)
        {
            if (i < _inventory.bookItems.Count)
            {
                if (_inventory.bookItems[i].itemAmount >= 2)
                {
                    _itemBookAmountText[i].enabled = true;
                    ChangeItemsAmountText();
                }
                else
                {
                    _itemBookAmountText[i].enabled = false;
                    ChangeItemsAmountText();
                }
                _bookSlots[i].AddItem(_inventory.bookItems[i]);
            }
            else
            {
                if (i < _inventory.bookItems.Count)
                {
                    ChangeItemsAmountText();
                }
                _itemBookAmountText[i].enabled = false;
                _bookSlots[i].ClearSlot();
            }

        }
        for (var i = 0; i < _ingridiensSlots.Length; i++)
        {
            if (i < _inventory.ingridiensItems.Count)
            {
                if (_inventory.ingridiensItems[i].itemAmount >= 2)
                {
                    _itemIngridienAmountText[i].enabled = true;
                    ChangeItemsAmountText();
                }
                else
                {
                    _itemIngridienAmountText[i].enabled = false;
                    ChangeItemsAmountText();
                }
                _ingridiensSlots[i].AddItem(_inventory.ingridiensItems[i]);

            }
            else
            {
                if (i < _inventory.ingridiensItems.Count)
                {
                    ChangeItemsAmountText();
                }
                _itemIngridienAmountText[i].enabled = false;
                _ingridiensSlots[i].ClearSlot();
            }
        }
    }


    private void ChangeItemsAmountText()
    {
        for (var i = 0; i < _inventory.weaponItems.Count; i++)
        {
            if (i < _inventory.weaponItems.Count)
            {
                _itemWeaponAmountText[i].text = Convert.ToString(_inventory.weaponItems[i].itemAmount);
            }
        }
        for (var i = 0; i < _inventory.apperanceItems.Count; i++)
        {
            if (i < _inventory.apperanceItems.Count)
            {
                _itemApperanceAmountText[i].text = Convert.ToString(_inventory.apperanceItems[i].itemAmount);
            }
        }
        for (var i = 0; i < _inventory.potionItems.Count; i++)
        {
            if (i < _inventory.potionItems.Count)
            {
                _itemPotionAmountText[i].text = Convert.ToString(_inventory.potionItems[i].itemAmount);
            }
        }
        for (var i = 0; i < _inventory.foodItems.Count; i++)
        {
            if (i < _inventory.foodItems.Count)
            {
                _itemFoodAmountText[i].text = Convert.ToString(_inventory.foodItems[i].itemAmount);
            }
        }
        for (var i = 0; i < _inventory.bookItems.Count; i++)
        {
            if (i < _inventory.bookItems.Count)
            {
                _itemBookAmountText[i].text = Convert.ToString(_inventory.bookItems[i].itemAmount);
            }
        }
        for (var i = 0; i < _inventory.ingridiensItems.Count; i++)
        {
            if (i < _inventory.ingridiensItems.Count)
            {
                _itemIngridienAmountText[i].text = Convert.ToString(_inventory.ingridiensItems[i].itemAmount);
            }

        }
    }

}