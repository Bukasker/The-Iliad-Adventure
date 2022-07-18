using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    public GameObject inventory;
    public static bool IsInventoryActive;

    private void Start()
    {
        inventory.SetActive(false);
    }
    private void Update()
    {
        inventory.SetActive(IsInventoryActive);
    }
}

