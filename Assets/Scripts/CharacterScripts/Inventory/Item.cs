using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]

public class Item : ScriptableObject
{
    new public string Name = "New Item";
    public Sprite Icon = null;
    public float Value = 0f;
    public float Weight = 0f;
    public int maxStack = 99;
    public int itemAmount = 1;
    
}
