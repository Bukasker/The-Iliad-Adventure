using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentMenager : MonoBehaviour
{
    #region Singleton

    public static EquipmentMenager Instance;

    public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);
    public OnEquipmentChanged onEquipmentChanged;
    private void Awake()
    {
        Instance = this;
    }
    #endregion

    private Equipment[] _currentEquipment;
    [SerializeField] private EquipmentSlotUI[] _equipmentSlotUI;
    private Inventory _inventory;



    [SerializeField] private ItemPickUp _weaponItem;

    private void Start()
    {
        _inventory = Inventory.Instance;

        int numArmorSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        _currentEquipment = new Equipment[numArmorSlots];
    }

    public void Equip (Equipment newItem)
    {
        int slotIndex = (int)newItem.equipSlot;
        Equipment oldItem = null;

        if(_currentEquipment[slotIndex] != null)
        {
            oldItem = _currentEquipment[slotIndex];
            _inventory.Add(oldItem);
        }
        if(onEquipmentChanged != null)
        {
            onEquipmentChanged.Invoke(newItem, oldItem);
        }
        _equipmentSlotUI[slotIndex].EquipItem(newItem);
        _currentEquipment[slotIndex] = newItem;

        if (_currentEquipment[0] != null && newItem.equipSlot == EquipmentSlot.Sword)
        {
            _weaponItem.Item = newItem;
        }
    }

    public void Unequip(int slotIndex)
    {
        if (_currentEquipment[slotIndex] != null)
        {
            Equipment oldItem = _currentEquipment[slotIndex];

            _inventory.Add(oldItem);
            _equipmentSlotUI[slotIndex].EquipItem(oldItem);

            _currentEquipment[slotIndex] = null;

            if (onEquipmentChanged != null)
            {
                onEquipmentChanged.Invoke(null, oldItem);
            }
        }
    }
}
