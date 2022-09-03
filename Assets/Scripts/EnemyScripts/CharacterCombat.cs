using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    CharacterStats myStats;
    public float attackSpeed = 1f;
    private float attackCooldown = 0f;


    private void Start()
    {
        myStats = GetComponent<CharacterStats>();      
    }
    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }
    public void Attack(CharacterStats targesStats)
    {
        if (attackCooldown <= 0f)
        {
            targesStats.TakeDamage(myStats.damage.GetValue());
            attackCooldown = 1f / attackSpeed;
        }
        else if (gameObject.name == "Player")
        {
            targesStats.TakeDamage(myStats.damage.GetValue());
        }

    }

}
