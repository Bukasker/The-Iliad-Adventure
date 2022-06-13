using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandsAnimation : MonoBehaviour
{
    private Animator _HandsAnimator;

    public SpriteRenderer handsSprite;

    [SerializeField] private bool haveWeapont = false;

    public GameObject _Hand;

    void Start()
    {
        handsSprite = GetComponent<SpriteRenderer>();
        _HandsAnimator = GetComponent<Animator>();
        handsSprite.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0) && haveWeapont)
        {
            handsSprite.enabled = true;
            SwordAttack();
        }
    }
    private void SwordAttack()
    {
        _HandsAnimator.SetBool("isEndAttacking", false);
        _HandsAnimator.SetTrigger("isAttacking");
    }
    public void SetActiveFalse()
    {
        _HandsAnimator.SetBool("isEndAttacking", true);
        handsSprite.enabled = false;
    }
}
