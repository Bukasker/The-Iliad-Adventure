using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    public Weapon Weapon;
    private void Start()
    {
        Item.itemAmount = 1;
    }
}
