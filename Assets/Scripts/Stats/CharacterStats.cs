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
    public int basicArmorPenetraiton = 1;

    public float currentHealth;

    public Stat damage;
    public Stat armor;
    [SerializeField] public GameObject _sliderGameObject;
    [SerializeField] public Slider _slider;

    private void Awake()
    {
        if(gameObject.name != "Player")
        {
            _sliderGameObject.SetActive(false);
        }
        _slider = _sliderGameObject.GetComponent<Slider>();
    }
    public virtual void TakeDamage(int damage)
    {}
    public virtual void Die()
    {
        //Character is dead
    }

}
