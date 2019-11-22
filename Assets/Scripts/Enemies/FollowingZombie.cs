using UnityEngine;

namespace Enemies
{
    public class FollowingZombie : AEnemy
    {
        public GameObject player;
        public override float Health { get; set; } = 50f;
        public override float Speed { get; set; } = 0.5f;
        public override float Damage { get; set; } = 20f;
        public override float ShotSpeed { get; set; } = 0f;

        void Start()
        {
            player = GameObject.Find("Player");
            _rbody = GetComponent<Rigidbody>();
            _toFollow = player.transform.Find("Main Camera").gameObject;
        }
        
        public override void AtackAction()
        {
            // do nothing
        }

        public override void MoveAction()
        {
            var position = transform.position;
            position += (player.transform.position - transform.position) * Speed * Time.deltaTime;
            var lookPosition = _toFollow.transform.position;
            lookPosition.y = position.y;
            transform.LookAt(lookPosition);
        }

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            _rbody.AddForce(transform.position - player.transform.position);
        }

        private Rigidbody _rbody;
        private GameObject _toFollow;
    }
}