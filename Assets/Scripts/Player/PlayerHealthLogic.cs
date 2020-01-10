using System.Globalization;
using Player.Items;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerHealthLogic : MonoBehaviour
    {
        public float Health = 100f;
        public GameObject HealthText; 
        void Start()
        {
            _playerController = GetComponent<PlayerController>();
            HealthText.GetComponent<Text>().text = ((int) Health).ToString();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (Health <= 0)
            {
                return;
            }
            
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
            HealthText.GetComponent<Text>().text = ((int) Health).ToString();
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