using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _PlayerAnimator;
    private Rigidbody _rb;

    [SerializeField] private GameObject Player;
    [SerializeField] private GameObject[] _enemy;

    [SerializeField] GameObject PlayerHands;

    public float rotationSpeed;
    public float jumpSpeed;
    private float ySpeed;
    public float runSpeed = 10f;
    private float PlayerSpeed = 0;

    float horizontal;
    float vertical;

    private CharacterController characterController;

    public bool isGrounded;
    public bool isJumping;
    private bool _isMoving;
    [SerializeField] private bool haveWeapon = false;

    public Vector3 movementDirection;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();
        _PlayerAnimator = GetComponent<Animator>();
        Player = gameObject;
    }

    private void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");
        var verticalInput = Input.GetAxis("Vertical");

        movementDirection = new Vector3(horizontalInput, 0, verticalInput);
        var magnitude = Mathf.Clamp01(movementDirection.magnitude) * runSpeed;
        movementDirection.Normalize();

        ySpeed += Physics.gravity.y * Time.deltaTime * 2;

        _PlayerAnimator.SetFloat("FloatMoveDirction", movementDirection.z);

        if (characterController.isGrounded)
        {
            isGrounded = true;
            _PlayerAnimator.SetBool("isGrounded", true);
            ySpeed = -0.5f;
            _PlayerAnimator.SetBool("isFalling", false);
            if (Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                ySpeed = jumpSpeed;
                _PlayerAnimator.SetBool("isJumping", true);
            }
        }
        else
        {
            _PlayerAnimator.SetBool("isGrounded", false);
            isGrounded = false;
            isJumping = false;
            characterController.stepOffset = 0;
        }

        var velocity = movementDirection * magnitude;
        velocity.y = ySpeed;

        characterController.Move(velocity * Time.deltaTime);
        if (((isJumping && velocity.y < 0) || velocity.y < -2) && !isGrounded)
        {
            _PlayerAnimator.SetBool("isFalling", true);
            _PlayerAnimator.SetBool("isJumping", false);
        }

        if (movementDirection != Vector3.zero)
        {
            var toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);

            transform.rotation =
                Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);
            _isMoving = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.localEulerAngles = new Vector3(0, 0, 0);
            _isMoving = true;
        }
        else if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
        {
            _isMoving = false;
        }

        if (_isMoving)
        {
            PlayerSpeed += Time.deltaTime * 2f;
            runSpeed = 5;
            runSpeed += PlayerSpeed * 3;
            if (PlayerSpeed > 1.5f)
            {
                PlayerSpeed = 1.5f;
            }

            _PlayerAnimator.SetBool("isMoving", true);
            _PlayerAnimator.SetFloat("Speed", PlayerSpeed);
        }
        else
        {
            PlayerSpeed = 0f;
            _PlayerAnimator.SetBool("isMoving", false);
        }

        if (Input.GetMouseButtonDown(0) && haveWeapon)
        {
            SwordAttack();
        }

        if (Input.GetMouseButtonDown(0) && !haveWeapon)
        {
            Attack();
        }

        if (Input.GetMouseButtonDown(1) && !haveWeapon)
        {
            StrongAttack();
        }
    }

    private void SwordAttack()
    {
        _PlayerAnimator.SetTrigger("isAttacking");
    }

    private void Attack()
    {
        _PlayerAnimator.SetTrigger("isPunching");
    }

    private void StrongAttack()
    {
        _PlayerAnimator.SetTrigger("isPunchingStrong");
    }

    public void AnimAtackEnd()
    {
        _PlayerAnimator.SetTrigger("isAttacking");
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Physics.IgnoreCollision(collision.collider, characterController);
        }
    }
}