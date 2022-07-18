using UnityEngine;
using System.Linq;
using TMPro;
using System;
public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField] private TextMeshProUGUI[] itemAmountText;
    [SerializeField] private InventorySlot[] slots;
    public static InventoryUI instanceUI;

    #region Singeton
    void Awake()
    {
        if(instanceUI != null)
        {
            Debug.Log("Error: More than one instance of Inventory found");
            return;
        }
        instanceUI = this;

        inventory = Inventory.Instance;
        inventory.onItemChangedCallback += UpdateUI;

        slots = GameObject.FindGameObjectsWithTag("slot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
        itemAmountText = GameObject.FindGameObjectsWithTag("itemAmount").Select(s => s.GetComponent<TextMeshProUGUI>()).ToArray();
    }
    #endregion
    void UpdateUI()
    {

        for (var i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                Debug.Log("ADDED " + inventory.items[i]);
                slots[i].AddItem(inventory.items[i]);
                
                if (inventory.items[i].itemAmount >= 2)
                {

                    itemAmountText[i].enabled = true;
                    itemAmountText[i].text = Convert.ToString(inventory.items[i].itemAmount);
                }
            }
            else
            {
                slots[i].ClearSlot();
            }
        } 
    }
}