using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerPunchingScript : MonoBehaviour
    {
        [SerializeField] private Transform _player;
        [SerializeField] private float _force = 200f;
        [SerializeField] private float _playerPositonModifer = 0.5f;

        // Events
     //   public static event EventHandler<PunchedEnemyEventArgs> OnPlayerPunchedEnemy;
        private void OnTriggerEnter(Collider col)
        {
            {
                if (col.CompareTag("Enemy") == false) return;

              //  OnPlayerPunchedEnemy?.Invoke(this, new PunchedEnemyEventArgs(gameObject, col.gameObject));

                Debug.Log($"{gameObject.name} collided with {col.name}");

                var enemyRb = col.GetComponent<Rigidbody>();

                var playerPosition = new Vector3(_player.transform.position.x, _player.transform.position.y - _playerPositonModifer, _player.transform.position.z);
                var enemyPosition = col.transform.position;

                var kickDirection = (enemyPosition - playerPosition).normalized;

                enemyRb.AddForce(kickDirection * _force, ForceMode.Impulse);
            }
        }
    }
}
