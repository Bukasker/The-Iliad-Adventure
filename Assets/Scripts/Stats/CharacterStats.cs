using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterStats : MonoBehaviour
{
    public int MinHealth = 0;
    public int MaxHealth = 100;
    public int Lvl = 1;
    public int Gold;

    public float currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    [SerializeField] private Slider _slider;

    private void Awake()
    {
        currentHealth = MaxHealth;
        _slider.maxValue = MaxHealth;
        _slider.minValue = MinHealth;
        _slider.value = MaxHealth;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage)
    {
        damage -= armor.GetValue();
        damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= damage;
        _slider.value = currentHealth;
        Debug.Log( transform.name + " takes " + damage +" damage.");

       if(currentHealth <= 0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        //Character is dead
        Debug.Log("Player died");
    }

}
