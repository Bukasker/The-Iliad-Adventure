using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    public Item Item;

    private void Start()
    {
        Item.itemAmount = 1;
    }
}
