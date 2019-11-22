using UnityEngine;

namespace Player.Items
{
    public class Bullet : MonoBehaviour, IBullet
    {
        public string ShooterTag { get; set; }

        private void Start()
        {
            tag = ShooterTag == "Player" ? "PlayerBullet" : "EnemyBullet";
        }

        void Update()
        {
            _lifeTime += Time.deltaTime;
            
            if (_lifeTime > ExistanceTime)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.CompareTag(ShooterTag) && !other.CompareTag(tag) && !Pircing)
            {     
                Destroy(gameObject);                
            }
        }

        private float _lifeTime = 0f;

        public float HurtValue { get; set; } = 0f;
        public float ExistanceTime { get; set; } = 1f;
        public bool Pircing { get; set; } = false;
    }
}