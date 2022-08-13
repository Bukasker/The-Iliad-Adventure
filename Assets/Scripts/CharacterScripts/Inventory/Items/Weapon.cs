using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Inventory/Weapon")]

public class Weapon : ScriptableObject
{
    public float Damage = 0f;
    public float Range = 0f;
    public float Speed = 0f;
}
