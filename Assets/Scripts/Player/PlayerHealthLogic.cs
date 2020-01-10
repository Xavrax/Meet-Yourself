using Player.Items;
using UnityEngine;

namespace Player
{
    public class PlayerHealthLogic : MonoBehaviour
    {
        public float Health = 100f;

        void Start()
        {
            _playerController = GetComponent<PlayerController>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("EnemyBullet"))
            {
                return;
            }
            
            var bullet = other.gameObject.GetComponent<Bullet>();
            
            if (bullet == null)
            {
                Debug.LogError("Bullet is not a Bullet!");
                return;
            }
            Health -= bullet.HurtValue;
            CheckIfLoseCondition();
        }

        private void CheckIfLoseCondition()
        {
            if (Health > 0f)
            {
                return;
            }
            
            Debug.Log("You Lose!");
            _playerController.Die();
        }

        private PlayerController _playerController;
    }
}