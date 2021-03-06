using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public static Inventory Instance;

    #region Singeton
    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Error : More than one instance of Inventory found");
            return;
        }
        Instance = this;
    }
    #endregion

    public void Add(Item item)
    {
        if (items.Contains(item) && item.itemAmount <= item.maxStack)
        {
            item.itemAmount += 1;
            if (items.Contains(item) && item.itemAmount > item.maxStack)
            {
                Debug.LogWarning("Alert: No more space in stack");
                item.itemAmount -= 1;
                //TODO: Throwing item
            }
        }
        else
        {
            Debug.Log("ADDITEM");
            items.Add(item);
        }
        onItemChangedCallback.Invoke();
    }
    public void Remove(Item item)
    {
        Debug.Log("REMOVEITEM");
        items.Remove(item);
        onItemChangedCallback.Invoke();
    }
}
