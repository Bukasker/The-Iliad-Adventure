using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float PatrolTime = 15f;
    public float AggroRange = 10f;
    public Transform[] Waypoints;

    int _index;
    float _speed, agentSpeed;
    float agentSpeedModifier = 1.5f;
    Transform Player;
    CharacterCombat _combat;

    public Animator _animator;
    NavMeshAgent _agent;
    bool _isAttacking;
    public bool _wasAttacked;
    private bool _canAttack;
    public bool isDead;

    private SpriteRenderer _spriteRenderer;
    private SphereCollider _sphereCollider;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        if (_agent != null) { agentSpeed = _agent.speed; }
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        _index = Random.Range(0, Waypoints.Length);
        _combat = GetComponent<CharacterCombat>();
        _sphereCollider = GetComponent<SphereCollider>();
        InvokeRepeating("Tick", 0, 0.1f);

        if (Waypoints.Length > 0)
        {
            InvokeRepeating("Patrol", 0, PatrolTime);
        }
    }
    private void Update()
    {
        if(_agent.velocity.magnitude >= 1f && !_wasAttacked)
        {
            _animator.SetBool("isMoving", true);
        }
        else
        {
            _animator.SetBool("isMoving", false);
        }
        if (isDead)
        {
            CancelInvoke();
            _animator.SetBool("isAttacking", false);
        }
    }

    private void Patrol()
    {
        _index = _index == Waypoints.Length - 1 ? 0 : _index + 1;
    }

    private void Tick()
    {
        if (!isDead) 
        {
            var randomNum = Random.Range(0, 100);
            if (randomNum >= 50 && !_isAttacking && _agent.velocity.magnitude <= 1f)
            {
                _animator.SetTrigger("isEating");
            }
            else if (randomNum < 50)
            {
                _agent.destination = Waypoints[_index].position;
                _agent.speed = agentSpeed / agentSpeedModifier;

                if (Player != null && Vector3.Distance(transform.position, Player.position) < AggroRange && _wasAttacked)
                {
                    _agent.destination = Player.position;
                    _agent.speed = agentSpeed;
                    _isAttacking = true;
                    _animator.SetBool("isAttacking", true);
                    if (Player.position.x > transform.position.x)
                    {
                        _spriteRenderer.flipX = true;
                    }
                    else
                    {
                        _spriteRenderer.flipX = false;
                    }
                    CharacterStats playerStats = Player.GetComponent<CharacterStats>();
                    if (_canAttack)
                    {
                        _combat.Attack(playerStats);
                    }
                }
                else if (Player != null && Vector3.Distance(transform.position, Player.position) > AggroRange)
                {
                    _isAttacking = false;
                    _wasAttacked = false;
                    _agent.destination = Waypoints[_index].position;
                    _agent.speed = agentSpeed / agentSpeedModifier;
                    _animator.SetBool("isAttacking", false);
                }
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, AggroRange);
    }



    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.CompareTag("Player") == false) return;

            _canAttack = true;
        }
    }
    private void OnTriggerExit(Collider col)
    {
        {
            if (col.CompareTag("Player") == false) return;

            _canAttack = false;
        }
    }
}
