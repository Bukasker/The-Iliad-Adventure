using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentTransform : MonoBehaviour
{
    private Equipment[] _currentEquipment;

    [SerializeField] private Transform _weaponHandTransforms;
    [SerializeField] private Transform _weaponSheathedTransform;

    [SerializeField] private Transform _bowHandTransform;
    [SerializeField] private Transform _bowSheathedTransform;

    [SerializeField] private Transform _helmetTranform;


    [SerializeField] private ItemPickUp _weaponItem;


    private void Start()
    {
        int numArmorSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
        _currentEquipment = new Equipment[numArmorSlots];
    }
    public void ChangeEquipTransform(Item item)
    {
        if(_currentEquipment[0] != null)
        {
            _weaponItem.Item = item;
        }
    }
}
