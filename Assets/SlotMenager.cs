using System.Collections;
using System.Linq;
using UnityEngine;
public class SlotMenager : MonoBehaviour
{
    [SerializeField] private InventorySlot[] _weaponSlots;
    [SerializeField] private InventorySlot[] _apperanceSlots;
    [SerializeField] private InventorySlot[] _potionSlots;
    [SerializeField] private InventorySlot[] _foodSlots;
    [SerializeField] private InventorySlot[] _bookSlots;
    [SerializeField] private InventorySlot[] _ingridiensSlots;
    private SlotMenager _instanceSlotMengaer;
    [SerializeField] private TrashUI _trashUI;
  
    private bool lastBool;
    private bool isItemRemove;
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
            if (_weaponSlots[i].stickToCursor.iconIsMoved == true && _trashUI.mouse_over && _weaponSlots[i].stickToCursor.buttonPressed == false)
            {
                _weaponSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _apperanceSlots.Length; i++)
        {
            if (_apperanceSlots[i].stickToCursor.iconIsMoved == true && _trashUI.mouse_over && _apperanceSlots[i].stickToCursor.buttonPressed == false)
            {
                _apperanceSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _potionSlots.Length; i++)
        {
            if (_potionSlots[i].stickToCursor.iconIsMoved == true && _trashUI.mouse_over && _potionSlots[i].stickToCursor.buttonPressed == false)
            {
                _potionSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _foodSlots.Length; i++)
        {
            if (_foodSlots[i].stickToCursor.iconIsMoved == true && _trashUI.mouse_over && _foodSlots[i].stickToCursor.buttonPressed == false)
            {
                _foodSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _bookSlots.Length; i++)
        {
            if (_bookSlots[i].stickToCursor.iconIsMoved == true && _trashUI.mouse_over && _bookSlots[i].stickToCursor.buttonPressed == false)
            {
                _bookSlots[i].OnRemoveItem();
            }
        }
        for (var i = 0; i < _ingridiensSlots.Length; i++)
        {
            if (_ingridiensSlots[i].stickToCursor.iconIsMoved == true && _trashUI.mouse_over && _ingridiensSlots[i].stickToCursor.buttonPressed == false)
            {
                _ingridiensSlots[i].OnRemoveItem();
            }
        }
    }
}
