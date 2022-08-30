using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    void Start()
    {
        EquipmentMenager.Instance.onEquipmentChanged += OnEquipmentChanged;
    }

    void OnEquipmentChanged(Equipment newItem,Equipment oldItem)
    {
        if(newItem != null)
        {
            armor.AddMofifier(newItem.armorModifier);
            damage.AddMofifier(newItem.damageModifier);
        }
        if(oldItem != null)
        {
            armor.AddMofifier(oldItem.armorModifier);
            damage.AddMofifier(oldItem.damageModifier);
        }
    }
}
