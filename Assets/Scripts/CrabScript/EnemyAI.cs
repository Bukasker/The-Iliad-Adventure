using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using Assets.Scripts.DataScripts;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class EnemyAI : MonoBehaviour
{
    private Vector3 _startPosition;
    private Vector3 _targetPosition;

    [SerializeField] private float maxDistance;
    [SerializeField] private float speed;
    [SerializeField] private float speedWhenAttacking;
    [SerializeField] private float _randomBehaviourInterval = 5f;
    [SerializeField] private float playerPostionModfierY = 0.9f;
    
    private bool _hasBeenAttacked;
    private GameObject _attacker;

    private bool _isMoving;

    private Animator _crabAnimator;

    [SerializeField] private GameObject _player;

    private void Start()
    {
        _crabAnimator = GetComponent<Animator>();
        RandomizeBehaviour();

        PlayerPunchingScript.OnPlayerPunchedEnemy += OnPlayerPunchedEnemy;
    }

    private void OnDisable()
    {
        PlayerPunchingScript.OnPlayerPunchedEnemy -= OnPlayerPunchedEnemy;
    }

    private void OnPlayerPunchedEnemy(object sender, PunchedEnemyEventArgs punchedEnemyEventArgs)
    {
        if (punchedEnemyEventArgs.PunchedEnemy.transform != gameObject.transform) return;

        _hasBeenAttacked = true;
        _attacker = punchedEnemyEventArgs.Attacker;
    }

    private void Awake()
    {
        _startPosition = transform.position;
        _isMoving = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        // dobr¹ praktyk¹ jest stworzenie sobie klasy ktora zawiera tagi, dlaczego? 
        // bo gdy zmienisz na przyklad tag albo usuniesz to w kodzie dzieki tej klasie pokaze Ci b³êdy, gdy wpiszesz je za pomoca stringów to Ci ich nie pokaze
        // zrobie Ci teraz taka klase

        // zrobimy cos taiego, ¿e gracz bêdzie wywolwywac event jesli jebnal gameobject o tagu enemy, oki?
        // enemy bedzie ten event subksrybowaæ jesli go wywolamy to ustawimy ze zostal zaatakowany na true i wtedy typ zachownia to bedzie wpierdol
        // TAK, nie bedziemy uzywac static, tory czyni dane pole taim samym dla kazdego ENEMY
    }

    public void MoveToNewTargetPosition()
    {
        if (_isMoving) return;
        StartCoroutine(MoveToTargetPosition(GetNewTargetPosition(), OnReachedTargetPosition));

        void OnReachedTargetPosition()
        {
            _crabAnimator.SetBool("isMoving", false);
            _isMoving = false;
            StopCoroutine(MoveToTargetPosition(Vector3.zero, null));
        }
    }

    public void RandomizeBehaviour()
    {
        InvokeRepeating(nameof(InvokeRandomBehaviour), 0f, _randomBehaviourInterval);
        

        //TODO: potrzebujemy zamienic InvokeRepeating na StartCoroutine po to by moc j¹ pozniej przerwac gdy enemy dostanie wpierdol i musi zrobic kontratak
        //TODO: zrobimy tak, ¿e gdy to ten enemy, zosta³ zaatakowany to zatrzymuejym jego zachowania
        //TODO: potrzebujemy ustalic jak daleko atakujacy musi byc od kraba by ten przesta³ go gonic
        //TODO: karzemy enemy biec za graczem
        //TODO: karzemy enemy atakowac gracza gdy jest blisko niego
        //TODO: jesli odleglosc od atakujecgo jest wieksza niz ustalona max to zaprzestajemy akcji i rozkazujemy mu wrocic do startowej pozycji
        //TODO: znów uruchamiamy coroutine RandomizeBehaviour

        // zamiast podawac cos w stringu uzywam nameof poniewaz gdybym teraz zmienil nazwe 
        // tej metody to w stringu ona sie nie zmieni ani nawet bledu Ci nie pokaze a w tkai sposob jak wyzej podkresli ze takiej metody nie ma albo cos
        // void Penis() {}
        // nameof(Penis) == "Penis" TO JEST TO SAMO
    }

    private Vector3 GetNewTargetPosition()
    {
        var x = UnityEngine.Random.Range(_startPosition.x - maxDistance, _startPosition.x + maxDistance);
        var y = _startPosition.y;
        var z = UnityEngine.Random.Range(_startPosition.z - maxDistance, _startPosition.z + maxDistance);

        return new Vector3(x, y, z);
    }

    private void EatAnimPlay()
    {
        _crabAnimator.SetTrigger("isEating");
    }
    private void IdleAnimPlay()
    {
        _crabAnimator.SetTrigger("isDoingSomething");
    }

    private readonly Random _rand = new();
    private void InvokeRandomBehaviour()
    {
        if (_isMoving) return;

        // TODO: jeœli zosta³ zaatakowany, przerwij wszyystkie akcje i napierdalaj sie z atakujacym
        // to nie moze byæ w invoke random behaviour dlatego, ¿e to nie jest random behaviour tylko konkretne zachowanie xD

        var values = Enum.GetValues(typeof(BehaviourType));
        var randomBehaviourType = (BehaviourType)values.GetValue(_rand.Next(0, values.Length - 1));

        switch (randomBehaviourType)
        {
            case BehaviourType.Walk:
                Debug.Log($"{gameObject.name} is walking.");
                MoveToNewTargetPosition();
                break;

            case BehaviourType.Idle:
                Debug.Log($"{gameObject.name} is idling.");
                IdleAnimPlay();
                break;

            case BehaviourType.Eat:
                Debug.Log($"{gameObject.name} is eating.");
                EatAnimPlay();
                break;
            case BehaviourType.Attack:
                Debug.Log($"{gameObject.name} is attacking.");
                break;

            default:
                throw new ArgumentOutOfRangeException($"{randomBehaviourType}");
        }
    }

    private IEnumerator MoveToTargetPosition(Vector3 targetPosition, Action onReachedTargetPosition)
    {
        _isMoving = true;
        _crabAnimator.SetBool("isMoving", true);

        while (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        onReachedTargetPosition?.Invoke();
    }

    private void EnemyAttack()
    {
        _crabAnimator.SetTrigger("isAttacking");
        var playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y - playerPostionModfierY , _player.transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, speed * Time.deltaTime);
    }

    public enum BehaviourType
    {
        Walk,
        Eat,
        Idle,
        Attack
    }
}
