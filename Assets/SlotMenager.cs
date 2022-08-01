using System.Collections;
using System.Linq;
using UnityEngine;
public class SlotMenager : MonoBehaviour
{
    [SerializeField] private InventorySlot[] slots;

    private SlotMenager instanceSlotMengaer;
    [SerializeField] private TrashUI trashUI;
  
    private bool lastBool;
    private bool isItemRemove;
    void Awake()
    {
        if (instanceSlotMengaer != null)
        {
            return;
        }
        instanceSlotMengaer = this;

        slots = GameObject.FindGameObjectsWithTag("slot").Select(s => s.GetComponent<InventorySlot>()).ToArray();
    }
    private void Update()
    {
        for (var i = 0; i < slots.Length; i++)
        {
            if (slots[i].stickToCursor.iconIsMoved == true && trashUI.mouse_over && slots[i].stickToCursor.buttonPressed == false)
            {
                slots[i].OnRemoveItem();
            }
        }
    }
}
