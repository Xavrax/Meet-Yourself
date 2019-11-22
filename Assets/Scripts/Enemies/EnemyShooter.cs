using System;
using Player.Items;
using UnityEngine;
using Random = System.Random;

namespace Enemies
{
    public class EnemyShooter : MonoBehaviour, IEnemy
    {
        public GameObject player;
        public GameObject playerCamera;
        public GameObject bulletsContainer;
        public GameObject projectile;
        
        public float Health { get; set; } = 10f;
        public float Speed { get; set; } = 2f;
        public float Damage { get; set; } = 10f;
        public float ShotSpeed { get; set; } = 8f;
        
        private void Start()
        {
            player = GameObject.Find("Player");
            playerCamera = GameObject.Find("Main Camera");
            bulletsContainer = GameObject.Find("Bullets");
            _rng = new Random();
            _desiredPosition = transform.position;
            _actualCooldown = CalculateCooldown();
        }

        private void Update()
        {
            _actualCooldown -= Time.deltaTime;
            if (_actualCooldown < 0f)
            {
                AtackAction();
            }
            MoveAction();
        }

        public void AtackAction()
        {
            Shoot();
            _actualCooldown = CalculateCooldown();
        }

        public void MoveAction()
        {
            transform.position += (_desiredPosition - transform.position) * Speed * Time.deltaTime;
            transform.LookAt(playerCamera.transform);
            ChooseDesiredPosition();
        }

        private float CalculateCooldown()
        {
            return _rng.Next(1, 3);
        }

        private void ChooseDesiredPosition()
        {
            if (_rng.Next(0, 20) == 0)
            {
                var x = _rng.Next(-3, 3);
                var z = _rng.Next(-3, 3);
                _desiredPosition = transform.position + new Vector3(x, 0, z);
            }
        }

        private void Shoot()
        {
            var bullet = Instantiate(
                projectile,
                transform.position,
                transform.rotation,
                bulletsContainer.transform
            );
            
            bullet.GetComponent<Rigidbody>().velocity = transform.TransformDirection(new Vector3(0f, 0f,ShotSpeed));
            var bulletStats = bullet.GetComponent<Bullet>();
            bulletStats.ExistanceTime = 4f;
            bulletStats.HurtValue = Damage;
            bulletStats.ShooterTag = "Enemy";
        }
        
        private float _actualCooldown = 0f;
        private Random _rng;
        private Vector3 _desiredPosition;
    }
}