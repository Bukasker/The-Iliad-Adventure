using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    [SerializeField] public int maxHealth = 100;

    public static int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }


    public static void takeDamege(int damage)
    {
        currentHealth -= damage;
    }
}
