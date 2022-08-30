using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class ItemPickUp : MonoBehaviour
{
    public Item Item;
    [SerializeField] private MeshFilter _mesh;
    [SerializeField] private Renderer _material;

    private void Start()
    {
        if(Item != null)
        Item.itemAmount = 1;
    }
    private void Update()
    {
        if (Item != null )
        {
            _mesh = GetComponent<MeshFilter>();
            _material = GetComponent<Renderer>();

            _mesh.mesh = Item.Mesh;
   
            GetComponent<Renderer>().materials = Item.Materials.ToArray(); 
            
        }
    }
}
