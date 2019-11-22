using System;
using System.Xml.Linq;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

namespace Player.Items
{
    public class MagicStick : MonoBehaviour, IEqItem
    {
        public GameObject projectile;
        public GameObject playerCamera;
        public GameObject bulletsContainer;
        public float MainCooldown { get; } = 1f;
        public float AdditionalCooldown { get; } = 1f;
        public float MainForceValue { get; } = 1f;
        public float AdditionalForceValue { get; } = 1f;
        public float ShotSpeed { get; } = 1f;
        
        public void MainAction(PlayerActionsController playerActions)
        {
            Shoot(playerActions).ShooterTag = "PlayerBullet";
        }

        public void AdditionalAction(PlayerActionsController playerActions)
        {
            var shots = 100;
            for (var i = 0; i < shots; i++)
            {
                Shoot(playerActions).ShooterTag = "Player";              
                playerCamera.transform.Rotate(0, 3.6f, 0);
            }
        }

        public void PasiveAction(float dt)
        {
            // do nothing
        }

        private IBullet Shoot(PlayerActionsController playerActions)
        {
            var bullet = Instantiate(
                projectile,
                playerCamera.transform.position,
                playerCamera.transform.rotation * new UnityEngine.Quaternion(50,30,30,10),
                bulletsContainer.transform
            );
            
            bullet.GetComponent<Rigidbody>().velocity = playerCamera.transform.TransformDirection(new Vector3(0f, 0f,playerActions.ShotSpeed));
            bullet.GetComponent<Bullet>().ExistanceTime = 2f;

            return bullet.GetComponent<Bullet>();
        }
    }
}