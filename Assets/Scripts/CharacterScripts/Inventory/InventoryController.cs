using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private GameObject inventory;
    public static bool IsInventoryActive;

    [SerializeField] private GameObject _weaponInventory;
    [SerializeField] private GameObject _apperanceInventory;
    [SerializeField] private GameObject _potionInventory;
    [SerializeField] private GameObject _foodInventory;
    [SerializeField] private GameObject _bookInventory;
    [SerializeField] private GameObject _ingridensInventory;

    private void Start()
    {
        _weaponInventory.SetActive(true);
        _apperanceInventory.SetActive(false);
        _potionInventory.SetActive(false);
        _foodInventory.SetActive(false);
        _bookInventory.SetActive(false);
        _ingridensInventory.SetActive(false);
        inventory.SetActive(false);
    }
    private void Update()
    {
        inventory.SetActive(IsInventoryActive);
    }
    #region InvetoryTypeButtons
    public void OnClickWeaponInventory()
    {
        Debug.Log("nice");
        _weaponInventory.SetActive(true);
        _apperanceInventory.SetActive(false);
        _potionInventory.SetActive(false);
        _foodInventory.SetActive(false);
        _bookInventory.SetActive(false);
        _ingridensInventory.SetActive(false);
    }
    public void OnClickApperanceInventory()
    {
        _weaponInventory.SetActive(false);
        _apperanceInventory.SetActive(true);
        _potionInventory.SetActive(false);
        _foodInventory.SetActive(false);
        _bookInventory.SetActive(false);
        _ingridensInventory.SetActive(false);
    }
    public void OnClickPotionInventory()
    {
        _weaponInventory.SetActive(false);
        _apperanceInventory.SetActive(false);
        _potionInventory.SetActive(true);
        _foodInventory.SetActive(false);
        _bookInventory.SetActive(false);
        _ingridensInventory.SetActive(false);
    }
    public void OnClickFoodInventory()
    {
        _weaponInventory.SetActive(false);
        _apperanceInventory.SetActive(false);
        _potionInventory.SetActive(false);
        _foodInventory.SetActive(true);
        _bookInventory.SetActive(false);
        _ingridensInventory.SetActive(false);
    }
    public void OnClickBookInventory()
    {
        _weaponInventory.SetActive(false);
        _apperanceInventory.SetActive(false);
        _potionInventory.SetActive(false);
        _foodInventory.SetActive(false);
        _bookInventory.SetActive(true);
        _ingridensInventory.SetActive(false);
    }
    public void OnClickIngridiensInventory()
    {
        _weaponInventory.SetActive(false);
        _apperanceInventory.SetActive(false);
        _potionInventory.SetActive(false);
        _foodInventory.SetActive(false);
        _bookInventory.SetActive(false);
        _ingridensInventory.SetActive(true);
    }
    #endregion
}

