using System.Collections;
using System.Linq;
using UnityEngine;
public class SlotMenager : MonoBehaviour
{
    private InventorySlot[] _weaponSlots;
    private InventorySlot[] _apperanceSlots;
    private InventorySlot[] _potionSlots;
    private InventorySlot[] _foodSlots;
    private InventorySlot[] _bookSlots;
    private InventorySlot[] _ingridiensSlots;

    private SlotMenager _instanceSlotMengaer;

    [SerializeField] private StickIconToCursor _trashStickToCursor;
    [SerializeField] private PotionSlot[] _potionSlot;


    [SerializeField] private StickIconToCursor _weaponStickToCursor;
    [SerializeField] private StickIconToCursor _bowStickToCursor;
    [SerializeField] private StickIconToCursor _helmetStickToCursor;
    [SerializeField] private StickIconToCursor _necklaceStickToCursor;
    [SerializeField] private StickIconToCursor _beltStickToCursor;
    [SerializeField] private StickIconToCursor _ringStickToCursor;

    private Inventory _inventory;
    void Awake()
    {
        if (_instanceSlotMengaer != null)
        {
            return;
        }
        _instanceSlotMengaer = this;

        _weaponSlots = GameObject.FindGameObjectsWithTag("weaponSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _apperanceSlots = GameObject.FindGameObjectsWithTag("apperanceSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _potionSlots = GameObject.FindGameObjectsWithTag("potionSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _foodSlots = GameObject.FindGameObjectsWithTag("foodSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _bookSlots = GameObject.FindGameObjectsWithTag("bookSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        _ingridiensSlots = GameObject.FindGameObjectsWithTag("ingridiensSlot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
    }
    private void Update()
    {
        for (var i = 0; i < _weaponSlots.Length; i++)
        {
            if (_weaponSlots[i].stickToCursor.iconIsMoved == true && _trashStickToCursor.mouse_over && _weaponSlots[i].stickToCursor.buttonPressed == false)
            {
                _weaponSlots[i].OnRemoveItem();
            }
            if(_weaponSlots[i].stickToCursor.iconIsMoved == true && _weaponStickToCursor.mouse_over && _weaponSlots[i].stickToCursor.buttonPressed == false)
            {
                _weaponSlots[i].UseItem();
            }
        }
        for (var i = 0; i < _apperanceSlots.Length; i++)
        {
            if (_apperanceSlots[i].stickToCursor.iconIsMoved == true && _trashStickToCursor.mouse_over && _apperanceSlots[i].stickToCursor.buttonPressed == false)
            {
                _apperanceSlots[i].OnRemoveItem();
            }
            if (_apperanceSlots[i].stickToCursor.iconIsMoved == true && (_bowStickToCursor.mouse_over|| _helmetStickToCursor.mouse_over || _necklaceStickToCursor.mouse_over || _beltStickToCursor.mouse_over || _ringStickToCursor.mouse_over) && _apperanceSlots[i].stickToCursor.buttonPressed == false)
            {
                _apperanceSlots[i].UseItem();
            }
        }
        for (var i = 0; i < _potionSlots.Length; i++)
        {
            if (_potionSlots[i].stickToCursor.iconIsMoved == true && _trashStickToCursor.mouse_over && _potionSlots[i].stickToCursor.buttonPressed == false)
            {
                _potionSlots[i].OnRemoveItem();
            }
            if (_potionSlots[i].stickToCursor.iconIsMoved == true && _potionSlots[i].stickToCursor.buttonPressed == false )
            {
                for (var p = 0; p < _potionSlot.Length; p++)
                {
                    if (_potionSlot[p].mouse_over)
                    {
                        _potionSlots[i].AddItemToPotionSlot(p);
                    }
                }
            }
        }
        for (var i = 0; i < _foodSlots.Length; i++)
        {
            if (_foodSlots[i].stickToCursor.iconIsMoved == true && _trashStickToCursor.mouse_over && _foodSlots[i].stickToCursor.buttonPressed == false)
            {
                _foodSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _bookSlots.Length; i++)
        {
            if (_bookSlots[i].stickToCursor.iconIsMoved == true && _trashStickToCursor.mouse_over && _bookSlots[i].stickToCursor.buttonPressed == false)
            {
                _bookSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _ingridiensSlots.Length; i++)
        {
            if (_ingridiensSlots[i].stickToCursor.iconIsMoved == true && _trashStickToCursor.mouse_over && _ingridiensSlots[i].stickToCursor.buttonPressed == false)
            {
                _ingridiensSlots[i].OnRemoveItem();
            }
        }
    }
}
