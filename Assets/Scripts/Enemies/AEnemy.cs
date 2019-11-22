using Player;
using Player.Items;
using UnityEngine;

namespace Enemies
{
    public abstract class AEnemy : MonoBehaviour, IEnemy
    {
        public abstract float Health { get; set; }
        public abstract float Speed { get; set; }
        public abstract float Damage { get; set; }
        public abstract float ShotSpeed { get; set; }
        public abstract void AtackAction();
        public abstract void MoveAction();

        protected void Update()
        {
            if (Health <= 0f)
            {
                Destroy(gameObject);
            }
            
            if (ActualCooldown < 0f)
            {
                AtackAction();
            }
            else
            {
                ActualCooldown -= Time.deltaTime;
            }
            
            MoveAction();
        }

        protected virtual void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag("PlayerBullet"))
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
        }
        
        protected float ActualCooldown = 0f;
    }
}