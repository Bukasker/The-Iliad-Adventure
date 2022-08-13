using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> weaponItems = new List<Item>();
    public List<Item> apperanceItems = new List<Item>();
    public List<Item> potionItems = new List<Item>();
    public List<Item> foodItems = new List<Item>();
    public List<Item> bookItems = new List<Item>();
    public List<Item> ingridiensItems = new List<Item>();

    public delegate void OnItemChange();
    public OnItemChange onItemChangedCallback;

    public static Inventory Instance;

    [SerializeField] private GameObject itemToSpawn;
    [SerializeField] private ItemPickUp itemPickUp;
    [SerializeField] private Transform PlayerPostion;

    [Range(1f, 10f)]
    [SerializeField] private float itemThrowForce = 2;

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
        if (item.ItemType == ItemTypes.Weapon)
        {
            if (weaponItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                ++item.itemAmount;
            }
            else if (weaponItems.Contains(item) && item.itemAmount == item.maxStack)
            {
                weaponItems.Add(item);
            }
            else
            {
                Debug.Log("ADDITEM");
                weaponItems.Add(item);
            }
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Apperance)
        {
            if (apperanceItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                ++item.itemAmount;
            }
            else if (apperanceItems.Contains(item) && item.itemAmount == item.maxStack)
            {
                apperanceItems.Add(item);
            }
            else
            {
                Debug.Log("ADDITEM");
                apperanceItems.Add(item);
            }
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Potion)
        {
            if (potionItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                ++item.itemAmount;
            }
            else if (potionItems.Contains(item) && item.itemAmount == item.maxStack)
            {
                potionItems.Add(item);
            }
            else
            {
                Debug.Log("ADDITEM");
                potionItems.Add(item);
            }
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Food)
        {
            if (foodItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                ++item.itemAmount;
            }
            else if (foodItems.Contains(item) && item.itemAmount == item.maxStack)
            {
                foodItems.Add(item);
            }
            else
            {
                Debug.Log("ADDITEM");
                foodItems.Add(item);
            }
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Book)
        {
            if (bookItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                ++item.itemAmount;
            }
            else if (bookItems.Contains(item) && item.itemAmount == item.maxStack)
            {
                bookItems.Add(item);
            }
            else
            {
                Debug.Log("ADDITEM");
                bookItems.Add(item);
            }
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Ingridiens)
        {
            if (ingridiensItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                ++item.itemAmount;
            }
            else if (ingridiensItems.Contains(item) && item.itemAmount == item.maxStack)
            {
                ingridiensItems.Add(item);
            }
            else
            {
                Debug.Log("ADDITEM");
                ingridiensItems.Add(item);
            }
            onItemChangedCallback.Invoke();
        }
    }
    public void Remove(Item item)
    {
        if (item.ItemType == ItemTypes.Weapon)
        {
            ThrowItem(item, item.itemAmount);
            if (weaponItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                item.itemAmount = 1;
            }
            Debug.Log("REMOVEITEM");
            weaponItems.Remove(item);
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Apperance)
        {
            ThrowItem(item, item.itemAmount);
            if (apperanceItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                item.itemAmount = 1;
            }
            Debug.Log("REMOVEITEM");
            apperanceItems.Remove(item);
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Potion)
        {
            ThrowItem(item, item.itemAmount);
            if (potionItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                item.itemAmount = 1;
            }
            Debug.Log("REMOVEITEM");
            potionItems.Remove(item);
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Food)
        {
            ThrowItem(item, item.itemAmount);
            if (foodItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                item.itemAmount = 1;
            }
            Debug.Log("REMOVEITEM");
            foodItems.Remove(item);
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Book)
        {
            ThrowItem(item, item.itemAmount);
            if (bookItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                item.itemAmount = 1;
            }
            Debug.Log("REMOVEITEM");
            bookItems.Remove(item);
            onItemChangedCallback.Invoke();
        }
        if (item.ItemType == ItemTypes.Ingridiens)
        {
            ThrowItem(item, item.itemAmount);
            if (ingridiensItems.Contains(item) && item.itemAmount < item.maxStack)
            {
                item.itemAmount = 1;
            }
            Debug.Log("REMOVEITEM");
            ingridiensItems.Remove(item);
            onItemChangedCallback.Invoke();
        }
    }

    private void ThrowItem(Item item, int numberToDrop)
    {
        itemPickUp = itemToSpawn.GetComponent<ItemPickUp>();
        itemPickUp.Item = item;

        for (var i = 0; i < numberToDrop; ++i)
        {
            var itemInScene = Instantiate(itemToSpawn, new Vector3(PlayerPostion.position.x, PlayerPostion.position.y, PlayerPostion.position.z + 1), Quaternion.identity);
            var itemInSceneRb = itemInScene.GetComponent<Rigidbody>();
            var randomPostion = new Vector3(Random.Range(0f, 2f), Random.Range(0f, 3f), Random.Range(0f, 1.5f));
            var positonToThrow = (randomPostion - PlayerPostion.position).normalized;
            itemInSceneRb.AddForce(positonToThrow * itemThrowForce, ForceMode.Impulse);
        }
    }
}
