using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactble : MonoBehaviour
{
    private SphereCollider _collider;
    [SerializeField] List<GameObject> _interactbleObjects;
    [SerializeField] private float _radius = 2.3f;
    private ItemPickUp itemPickUp;
    public GameObject FocusedItem;
    void Start()
    {
        _collider = GetComponent<SphereCollider>();
        _collider.radius = _radius;
    }

    void Update()
    {
        if (_interactbleObjects.Count != 0)
        {
            FocusedItem = _interactbleObjects[0];
        }
    }
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Item"))
        {
            AddtoArray(col.gameObject);
            Debug.Log("Player can interact with" + _interactbleObjects);
        }
    }
    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Item"))
        {
            RemovetoArray(col.gameObject);
        }
    }
    void AddtoArray(GameObject obj)
    {
        _interactbleObjects.Add(obj);
    }
    void RemovetoArray(GameObject obj)
    {
        _interactbleObjects.Remove(obj);
    }

    public void RemoveFirstItemOnList()
    {
        if (_interactbleObjects.Count != 0)
        {
            FocusedItem = _interactbleObjects[0];
            itemPickUp = FocusedItem.GetComponent<ItemPickUp>();
            Inventory.Instance.Add(itemPickUp.Item);
            Destroy(FocusedItem);
            _interactbleObjects.Remove(FocusedItem);
        }
    }
}