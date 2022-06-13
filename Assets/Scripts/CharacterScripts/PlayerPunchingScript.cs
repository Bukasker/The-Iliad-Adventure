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
        public static event EventHandler<PunchedEnemyEventArgs> OnPlayerPunchedEnemy; 

        // zrobimy ze event bedzie statyczny to znaczy ze jesli ktos zostal uderzony
        // (enemy, to sprawdzi czy to on zostal uderzony a jesli tak to zaczyna napierdalac tego co uderzyl
        // A NO TO TAK TO BEDZIE W ENEMY SCRIPT
        // narazie chce tylko go poinformowac ze dostal wpierdol xD _ TO ROBI MÓZG XD

        private void OnTriggerEnter(Collider col)
        {
            {
                if (col.CompareTag("Enemy") == false) return;

                OnPlayerPunchedEnemy?.Invoke(this, new PunchedEnemyEventArgs(gameObject, col.gameObject));

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
