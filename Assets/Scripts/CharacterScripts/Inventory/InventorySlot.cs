using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour
{
    public bool buttonPressed;
    [SerializeField] private Image icon;
    public Item item;
    public bool ItemRemoved;
    public StickToCursor stickToCursor;

    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.Icon;
        icon.enabled = true;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

    }
    public void OnRemoveItem()
    {
        Inventory.Instance.Remove(item);
    }
}