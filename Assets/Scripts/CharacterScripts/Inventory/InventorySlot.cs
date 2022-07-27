using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image icon;
    public Item item;
    public bool ItemRemoved;
    public StickToCursor stickToCursor;
   /* public GameObject Panel;
    public TrashUI trashUI;
    private void Awake()
    {
        Panel = GameObject.FindGameObjectWithTag("TrashPanel");
        trashUI = Panel.GetComponent<TrashUI>();
    }
   */
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.Icon;
        icon.enabled = true;

        ItemRemoved = false;
    }
    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

    }
    public void OnRemoveItem()
    {

    }
    private void Update()
    {
        //  if (stickToCursor.buttonPressed && trashUI.mouse_over)
        //  {
        //    Inventory.Instance.Remove(item);
        //  }
    }

}