using UnityEngine;

public class PlayerPunchingScript : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _force = 200f;
    [SerializeField] private float _playerPositonModifer = 0.5f;
    private EnemyController _enemyController;

    private void OnTriggerEnter(Collider col)
    {
        {
            if (col.CompareTag("Enemy") == false) return;

            var enemyScript = col.GetComponent<Enemy>();
            enemyScript.Interact();

            Debug.Log($"{gameObject.name} collided with {col.name}");

            _enemyController = col.GetComponent<EnemyController>();
            _enemyController._wasAttacked = true;

            var enemyRb = col.GetComponent<Rigidbody>();
            var playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y - _playerPositonModifer, _player.transform.position.z);
            var enemyPosition = col.transform.position;

            var kickDirection = (enemyPosition - playerPosition).normalized;

            enemyRb.AddForce(kickDirection * _force, ForceMode.Impulse);
        }
    }
}


